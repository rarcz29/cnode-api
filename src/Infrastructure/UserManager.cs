using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Identity;
using CNode.Application.Identity;
using CNode.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CNode.Infrastructure
{
    internal class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwt;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public UserManager(IUnitOfWork unitOfWork, IJwtService jwt, TokenValidationParameters tokenValidationParameters)
        {
            _unitOfWork = unitOfWork;
            _jwt = jwt;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<AuthenticationResult> AuthenticateAsync(string usernameOrEmail, string password)
        {
            var users = await _unitOfWork.Users.FindAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);

            if (users != null && users.Count() == 1)
            {
                var user = users.First();

                if (user.Password == password)
                {
                    var jwt = _jwt.CreateJwt(user);
                    var validatedToken = GetPrincipalFromToken(jwt);
                    var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                    var refreshToken = await SaveNewRefreshTokenAsync(user.Id, jti);
                    return new AuthenticationResult
                    {
                        Token = jwt,
                        RefreshToken = refreshToken
                    };
                }
            }

            // Throw exception
            return null;
        }

        public async Task<AuthenticationResult> RefreshAsync(string token, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(token);

            if (validatedToken == null)
            {
                return null; // TODO: return error or throw an exception
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var storedRefreshToken = await _unitOfWork.RefreshTokens.GetByToken(refreshToken);

            if (storedRefreshToken == null
                || DateTime.UtcNow > storedRefreshToken.ExpiryDate
                || storedRefreshToken.Invalidated
                || storedRefreshToken.Used
                || storedRefreshToken.JwtId != jti)
            {
                return null; // TODO: return error or throw an exception
            }

            storedRefreshToken.Used = true;
            _unitOfWork.RefreshTokens.Update(storedRefreshToken);
            await _unitOfWork.SaveChangesAsync();

            var user = _unitOfWork.Users.Get(int.Parse(validatedToken.Claims.Single(x => x.Type == "id").Value)); // TODO: TryParse
            var newToken = _jwt.CreateJwt(user);
            var newValidatedToken = GetPrincipalFromToken(newToken);
            var newJti = newValidatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var newRefreshToken = await SaveNewRefreshTokenAsync(user.Id, newJti);
            return new AuthenticationResult
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            };
        }

        public async Task RegisterAsync(string username, string email, string password, bool twoFactorEnabled = false)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                TwoFactorEnabled = twoFactorEnabled,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();
            // TODO: return value or exception when failured
        }

        public async Task RemoveAsync(int userId)
        {
            _unitOfWork.Users.Remove(userId);
            await _unitOfWork.SaveChangesAsync();
            // TODO: return value or exception when failured
        }
        private static bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                                                   StringComparison.InvariantCultureIgnoreCase);
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);

                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private async Task<string> SaveNewRefreshTokenAsync(int userId, string jti)
        {
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                JwtId = jti,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };

            _unitOfWork.RefreshTokens.Add(refreshToken);
            await _unitOfWork.SaveChangesAsync();
            return refreshToken.Token;
        }
    }
}

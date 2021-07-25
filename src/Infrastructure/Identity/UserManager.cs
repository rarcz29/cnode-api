using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Common.Interfaces.Data.Database;
using GitNode.Domain.Entities;
using GitNode.Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace GitNode.Infrastructure.Identity
{
    internal class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwt;
        private readonly IPasswordHasher _passwordHasher;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public UserManager(IUnitOfWork unitOfWork, IJwtService jwt, IPasswordHasher passwordHasher,
                           TokenValidationParameters tokenValidationParameters)
        {
            _unitOfWork = unitOfWork;
            _jwt = jwt;
            _passwordHasher = passwordHasher;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<AuthenticationResult> AuthenticateAsync(string usernameOrEmail, string password)
        {
            var users = (await _unitOfWork.Users.FindAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail)).ToList();

            if (users == null || users.Count() != 1)
                throw new AuthenticationException("You have entered an invalid username or email.");
            
            var user = users.First();

            if (!_passwordHasher.ValidatePassword(password, user.Password))
                throw new AuthenticationException("You have entered an invalid password.");
            
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

        public async Task<AuthenticationResult> RefreshAsync(string token, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(token);

            if (validatedToken == null)
            {
                throw new AuthenticationException("You have sent an invalid access token.");
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var storedRefreshToken = await _unitOfWork.RefreshTokens.GetByToken(refreshToken);

            if (storedRefreshToken == null
                || DateTime.UtcNow > storedRefreshToken.ExpiryDate
                || storedRefreshToken.Invalidated
                || storedRefreshToken.Used
                || storedRefreshToken.JwtId != jti)
            {
                throw new AuthenticationException("You have sent an invalid refresh token.");
            }

            storedRefreshToken.Used = true;
            _unitOfWork.RefreshTokens.Update(storedRefreshToken);
            await _unitOfWork.SaveChangesAsync();

            var user = _unitOfWork.Users.Get(int.Parse(validatedToken.Claims.Single(x => x.Type == "id").Value));
            var newToken = _jwt.CreateJwt(user);
            var newValidatedToken = GetPrincipalFromToken(newToken);
            var newJti = newValidatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var newRefreshToken = await SaveNewRefreshTokenAsync(user.Id, newJti);

            if (newToken == null || newRefreshToken == null)
            {
                throw new InternalServerException("Server has a problem with creating new tokens. Try again later.");
            }

            return new AuthenticationResult
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            };
        }

        public async Task RegisterAsync(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = _passwordHasher.CreateHash(password),
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Users.Add(user);
            var affected = await _unitOfWork.SaveChangesAsync();

            if (affected != 1)
            {
                throw new UserRegistrationException("User with that username or email already exists.");
            }
        }

        public async Task RemoveAsync(int userId)
        {
            _unitOfWork.Users.Remove(userId);
            var affected = await _unitOfWork.SaveChangesAsync();

            if (affected < 1)
            {
                throw new InternalServerException("Server has a problem with removing this user. Try again later.");
            }
        }
        private static bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return validatedToken is JwtSecurityToken jwtSecurityToken &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                                                   StringComparison.InvariantCultureIgnoreCase);
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);

            if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
            {
                throw new AuthenticationException("Server has a problem with authenticating the user.");
            }

            return principal;
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

using CNode.Application.Common.Data.Database;
using CNode.Application.Identity;
using CNode.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CNode.Infrastructure
{
    internal class UserManager : IUserManager
    {
        private readonly string _key;
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            // TODO: move key to the configuration file
            _key = "mykeyyfasgt9a87sgdofbhasg78aosd8fhbioasdgf87asogf";
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Authenticate(string username, string email, string password)
        {
            // TODO:
            //var user = new { Id = 1, Username = "myusername", Email = "test@email.com", Password = "password1234" };
            var users = await _unitOfWork.Users.FindAsync(u => u.Username == username || u.Email == email);

            if (users != null && users.Count() == 1)
            {
                var user = users.First();

                if (user.Password == password)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes(_key);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim(ClaimTypes.Email, user.Email)
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(60),
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(tokenKey),
                            SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }

            }

            // Throw exception
            return null;
        }

        public async Task Register(string username, string email, string password, bool twoFactorEnabled = false)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                TwoFactorEnabled = twoFactorEnabled
            };

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();
            // TODO: return value or exception when failured
        }

        public async Task Remove(int userId)
        {
            _unitOfWork.Users.Remove(userId);
            await _unitOfWork.SaveChangesAsync();
            // TODO: return value or exception when failured
        }
    }
}

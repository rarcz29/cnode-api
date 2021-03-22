using CNode.Application.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CNode.Infrastructure
{
    internal class UserManager : IUserManager
    {
        private readonly string _key;

        public UserManager()
        {
            // TODO: move key to the configuration file
            _key = "mykeyyfasgt9a87sgdofbhasg78aosd8fhbioasdgf87asogf";
        }

        public string Authenticate(string email, string password)
        {
            var user = new { Id = 1, Username = "myusername", Email = "test@email.com", Password = "password1234" };

            if (user != null && email == user.Email && user.Password == password)
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

            return null;
        }
    }
}

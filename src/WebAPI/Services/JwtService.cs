using CNode.Application.Common.Identity;
using CNode.Domain.Entities;
using CNode.WebAPI.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CNode.WebAPI.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateJwt(User user)
        {
            var jwtOptions = new JwtOptions();
            _configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions);
            var key = jwtOptions.Secret;
            var expirationTime = jwtOptions.TokenLifeTime;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    // TODO:
                    //new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim("id", user.Id.ToString()),
                    //new Claim(ClaimTypes.Name, user.Username),
                    new Claim("username", user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.Add(expirationTime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

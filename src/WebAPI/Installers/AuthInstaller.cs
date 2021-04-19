using CNode.Application.Common.Identity;
using CNode.WebAPI.Options;
using CNode.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CNode.WebAPI.Installers
{
    public class AuthInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();
            configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = CreateTokenValidationParameters(true, true, jwtOptions.Secret);
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            services.AddSingleton(CreateTokenValidationParameters(false, false, jwtOptions.Secret));
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<IJwtService, JwtService>();
        }

        private static TokenValidationParameters CreateTokenValidationParameters(bool requireExpirationTime, bool validateLifeTime, string jwtSecret)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(jwtSecret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = requireExpirationTime,
                ValidateLifetime = validateLifeTime,
                ClockSkew = TimeSpan.Zero
            };
        }
    }
}

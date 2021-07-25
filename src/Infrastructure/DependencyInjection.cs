using GitNode.Application.Common.Interfaces;
using GitNode.Infrastructure.Cryptography;
using GitNode.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GitNode.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserManager, UserManager>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            return services;
        }
    }
}

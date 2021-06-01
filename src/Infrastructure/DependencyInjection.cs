using CNode.Application.Common.Interfaces;
using CNode.Infrastructure.Cryptography;
using CNode.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CNode.Infrastructure
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

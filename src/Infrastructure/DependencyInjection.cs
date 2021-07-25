using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Application.Common.Interfaces;
using GitNode.Infrastructure.Cryptography;
using GitNode.Infrastructure.ExternalAPIs;
using GitNode.Infrastructure.ExternalAPIs.Common;
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
            services.AddSingleton<IAppHttpClient, AppHttpClient>();
            services.AddSingleton<IProcessorsProvider, ProcessorsProvider>();
            return services;
        }
    }
}

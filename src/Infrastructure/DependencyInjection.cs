using CNode.Application.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CNode.Infrastructure
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services)
        {
            services.AddSingleton<IUserManager, UserManager>();
            return services;
        }
    }
}

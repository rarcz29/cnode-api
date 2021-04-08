using CNode.Application.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CNode.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserManager, UserManager>();
            return services;
        }
    }
}

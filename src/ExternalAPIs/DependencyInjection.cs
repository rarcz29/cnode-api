using CNode.Application.Data.ExternalAPIs;
using Microsoft.Extensions.DependencyInjection;

namespace CNode.ExternalAPIs
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExteranlAPIs(this IServiceCollection services)
        {
            services.AddSingleton<IAppHttpClient, AppHttpClient>();
            return services;
        }
    }
}

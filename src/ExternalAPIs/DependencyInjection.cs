using CNode.Application.Common.Data.ExternalAPIs;
using CNode.ExternalAPIs.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CNode.ExternalAPIs
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExteranlAPIs(this IServiceCollection services)
        {
            services.AddSingleton<IAppHttpClient, AppHttpClient>();
            services.AddSingleton<IProcessorsProvider, ProcessorsProvider>();
            return services;
        }
    }
}

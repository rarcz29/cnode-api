using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.ExternalAPIs.Common;
using Microsoft.Extensions.DependencyInjection;

namespace GitNode.ExternalAPIs
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

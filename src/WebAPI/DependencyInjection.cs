using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CNode.WebAPI
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CNode", Version = "v1" });
            });
            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GitNode.WebAPI.Installers
{
    interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
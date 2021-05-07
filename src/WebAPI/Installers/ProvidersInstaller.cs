using CNode.Application.Common.Interfaces;
using CNode.WebAPI.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CNode.WebAPI.Installers
{
    public class ProvidersInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GitHubOAuth>(configuration.GetSection(nameof(GitHubOAuth)));
            services.AddSingleton<IGitHubOAuthProvider, GitHubOAuthProvider>();
        }
    }

    internal class GitHubOAuthProvider : IGitHubOAuthProvider
    {
        public GitHubOAuthProvider(IOptions<GitHubOAuth> options)
        {
            Options = options.Value;
        }

        public IGitHubOAuthOptions Options { get; }
    }
}

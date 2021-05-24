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
            services.Configure<BitbucketOAuth>(configuration.GetSection(nameof(BitbucketOAuth)));
            services.AddSingleton<IGitHubOAuthProvider, GitHubOAuthProvider>();
            services.AddSingleton<IBitbucketOAuthProvider, BitbucketOAuthProvider>();
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

    internal class BitbucketOAuthProvider : IBitbucketOAuthProvider
    {
        public BitbucketOAuthProvider(IOptions<BitbucketOAuth> options)
        {
            Options = options.Value;
        }

        public IBitbucketOAuthOptions Options { get; }
    }
}

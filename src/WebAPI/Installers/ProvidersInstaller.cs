using GitNode.Application.Common.Interfaces;
using GitNode.Application.Common.Interfaces.OAuth;
using GitNode.WebAPI.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GitNode.WebAPI.Installers
{
    public class ProvidersInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GitHubOAuth>(configuration.GetSection(nameof(GitHubOAuth)));
            services.Configure<BitbucketOAuth>(configuration.GetSection(nameof(BitbucketOAuth)));
            services.Configure<GitLabOAuth>(configuration.GetSection(nameof(GitLabOAuth)));
            services.AddSingleton<IGitHubOAuthProvider, GitHubOAuthProvider>();
            services.AddSingleton<IBitbucketOAuthProvider, BitbucketOAuthProvider>();
            services.AddSingleton<IGitLabOAuthProvider, GitLabOAuthProvider>();
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

    internal class GitLabOAuthProvider : IGitLabOAuthProvider
    {
        public GitLabOAuthProvider(IOptions<GitLabOAuth> options)
        {
            Options = options.Value;
        }

        public IGitLabOAuthOptions Options { get; }
    }
}

using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Application.Common.Interfaces;

namespace GitNode.Infrastructure.ExternalAPIs.GitHub
{
    internal class GithubProvider : IPlatformProvider
    {
        public GithubProvider(IAppHttpClient client, IGitHubOAuthProvider options)
        {
            Users ??= new GithubUserProcessor(client, options);
            Repositories ??= new GithubRepoProcessor(client);
        }

        public IUserProcessor Users { get; }

        public IRepoProcessor Repositories { get; }
    }
}

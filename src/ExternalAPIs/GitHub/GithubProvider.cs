using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Application.Common.Interfaces;

namespace CNode.ExternalAPIs.GitHub
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

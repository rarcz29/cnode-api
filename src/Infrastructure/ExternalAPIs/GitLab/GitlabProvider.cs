using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Application.Common.Interfaces;

namespace GitNode.Infrastructure.ExternalAPIs.GitLab
{
    internal class GitlabProvider : IPlatformProvider
    {
        public GitlabProvider(IAppHttpClient client, IGitLabOAuthProvider options)
        {
            Users ??= new GitlabUserProcessor(client, options);
            Repositories ??= new GitlabRepoProcessor(client);
        }

        public IUserProcessor Users { get; }

        public IRepoProcessor Repositories { get; }
    }
}

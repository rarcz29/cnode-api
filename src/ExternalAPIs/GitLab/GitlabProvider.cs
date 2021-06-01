using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Application.Common.Interfaces;

namespace CNode.ExternalAPIs.GitLab
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

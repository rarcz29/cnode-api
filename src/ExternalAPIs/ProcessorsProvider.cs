using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Application.Common.Interfaces;
using CNode.ExternalAPIs.GitHub;

namespace CNode.ExternalAPIs
{
    class ProcessorsProvider : IProcessorsProvider
    {
        public ProcessorsProvider(IAppHttpClient client, IGitHubOAuthProvider options)
        {
            Users ??= new UserProcessor(client, options);
            Repositories ??= new RepoProcessor(client);
        }

        public IUserProcessor Users { get; private set; }

        public IRepoProcessor Repositories { get; private set; }
    }
}

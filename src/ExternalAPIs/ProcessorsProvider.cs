using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Interfaces;
using CNode.ExternalAPIs.GitHub;

namespace CNode.ExternalAPIs
{
    internal class ProcessorsProvider : IProcessorsProvider
    {
        public ProcessorsProvider(IAppHttpClient client, IGitHubOAuthProvider options)
        {
            Github ??= new GithubProvider(client, options);
        }

        public IPlatformProvider Github { get; }
    }
}

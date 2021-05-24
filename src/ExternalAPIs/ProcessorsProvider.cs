using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Interfaces;
using CNode.ExternalAPIs.Bitbucket;
using CNode.ExternalAPIs.GitHub;

namespace CNode.ExternalAPIs
{
    internal class ProcessorsProvider : IProcessorsProvider
    {
        public ProcessorsProvider(IAppHttpClient client,
                                  IGitHubOAuthProvider githubOptions,
                                  IBitbucketOAuthProvider bitbucketOptions)
        {
            Github ??= new GithubProvider(client, githubOptions);
            Bitbucket ??= new BitbucketProvider(client, bitbucketOptions);
        }

        public IPlatformProvider Github { get; }

        public IPlatformProvider Bitbucket { get; }
    }
}

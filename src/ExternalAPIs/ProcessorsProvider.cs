using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Interfaces;
using CNode.ExternalAPIs.Bitbucket;
using CNode.ExternalAPIs.GitHub;
using CNode.ExternalAPIs.GitLab;

namespace CNode.ExternalAPIs
{
    internal class ProcessorsProvider : IProcessorsProvider
    {
        public ProcessorsProvider(IAppHttpClient client,
                                  IGitHubOAuthProvider githubOptions,
                                  IBitbucketOAuthProvider bitbucketOptions,
                                  IGitLabOAuthProvider gitlabOptions)
        {
            Github ??= new GithubProvider(client, githubOptions);
            Bitbucket ??= new BitbucketProvider(client, bitbucketOptions);
            Gitlab ??= new GitlabProvider(client, gitlabOptions);
        }

        public IPlatformProvider Github { get; }

        public IPlatformProvider Bitbucket { get; }

        public IPlatformProvider Gitlab { get; }
    }
}

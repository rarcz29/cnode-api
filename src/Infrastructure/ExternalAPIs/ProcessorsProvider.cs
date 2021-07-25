using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Application.Common.Interfaces;
using GitNode.Infrastructure.ExternalAPIs.Bitbucket;
using GitNode.Infrastructure.ExternalAPIs.GitHub;
using GitNode.Infrastructure.ExternalAPIs.GitLab;

namespace GitNode.Infrastructure.ExternalAPIs
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

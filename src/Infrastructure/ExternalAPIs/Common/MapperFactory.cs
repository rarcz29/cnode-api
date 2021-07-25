using GitNode.Infrastructure.ExternalAPIs.Interfaces;
using GitNode.Infrastructure.ExternalAPIs.Mappers;

namespace GitNode.Infrastructure.ExternalAPIs.Common
{
    internal static class MapperFactory
    {
        public static IGithubMapper CreateGithubMapper() => new GithubMapper();

        public static IBitbucketMapper CreateBitbucketMapper() => new BitbucketMapper();

        public static IGitlabMapper CreateGitlabMapper() => new GitlabMapper();
    }
}

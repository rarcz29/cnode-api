using GitNode.ExternalAPIs.Interfaces;
using GitNode.ExternalAPIs.Mappers;

namespace GitNode.ExternalAPIs.Common
{
    internal class MapperFactory
    {
        public static IGithubMapper CreateGithubMapper() => new GithubMapper();

        public static IBitbucketMapper CreateBitbucketMapper() => new BitbucketMapper();

        public static IGitlabMapper CreateGitlabMapper() => new GitlabMapper();
    }
}

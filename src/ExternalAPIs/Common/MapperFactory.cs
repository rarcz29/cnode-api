using CNode.ExternalAPIs.Interfaces;
using CNode.ExternalAPIs.Mappers;

namespace CNode.ExternalAPIs.Common
{
    internal class MapperFactory
    {
        public static IGithubMapper CreateGithubMapper() => new GithubMapper();

        public static IBitbucketMapper CreateBitbucketMapper() => new BitbucketMapper();
    }
}

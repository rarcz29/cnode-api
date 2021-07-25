using GitNode.Application.Common.Models;
using GitNode.ExternalAPIs.Models;

namespace GitNode.ExternalAPIs.Interfaces
{
    internal interface IBitbucketMapper
    {
        PlatformRepository Map(BitbucketRepository model);
        PlatformToken Map(BitbucketToken model);
        PlatformUser Map(BitbucketUser model);
    }
}

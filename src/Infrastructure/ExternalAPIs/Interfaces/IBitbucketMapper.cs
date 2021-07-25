using GitNode.Application.Common.Models;
using GitNode.Infrastructure.ExternalAPIs.Models;

namespace GitNode.Infrastructure.ExternalAPIs.Interfaces
{
    internal interface IBitbucketMapper
    {
        PlatformRepository Map(BitbucketRepository model);
        PlatformToken Map(BitbucketToken model);
        PlatformUser Map(BitbucketUser model);
    }
}

using CNode.Application.Common.Models;
using CNode.ExternalAPIs.Models;

namespace CNode.ExternalAPIs.Interfaces
{
    internal interface IBitbucketMapper
    {
        PlatformRepository Map(BitbucketRepository model);
        PlatformToken Map(BitbucketToken model);
        PlatformUser Map(BitbucketUser model);
    }
}

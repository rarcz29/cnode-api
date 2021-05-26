using CNode.Application.Common.Models;
using CNode.ExternalAPIs.Interfaces;
using CNode.ExternalAPIs.Models;

namespace CNode.ExternalAPIs.Mappers
{
    internal class BitbucketMapper : IBitbucketMapper
    {
        public PlatformRepository Map(BitbucketRepository model)
        {
            throw new System.NotImplementedException();
        }

        public PlatformToken Map(BitbucketToken model) => new()
        {
            AccessToken = model.access_token
        };

        public PlatformUser Map(BitbucketUser model) => new()
        {
            Id = model.account_id,
            Login = model.username,
            Name = model.nickname,
            Url = model.links.html.href,
        };
    }
}

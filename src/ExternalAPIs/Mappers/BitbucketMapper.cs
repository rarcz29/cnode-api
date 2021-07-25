using GitNode.Application.Common.Models;
using GitNode.ExternalAPIs.Interfaces;
using GitNode.ExternalAPIs.Models;

namespace GitNode.ExternalAPIs.Mappers
{
    internal class BitbucketMapper : IBitbucketMapper
    {
        public PlatformRepository Map(BitbucketRepository model)
        {
            throw new System.NotImplementedException();
        }

        public PlatformToken Map(BitbucketToken model) => new PlatformToken()
        {
            AccessToken = model.access_token
        };

        public PlatformUser Map(BitbucketUser model) => new PlatformUser()
        {
            Id = model.account_id,
            Login = model.username,
            Name = model.nickname,
            Url = model.links.html.href,
        };
    }
}

using GitNode.Domain.Platforms;
using GitNode.Infrastructure.ExternalAPIs.Interfaces;
using GitNode.Infrastructure.ExternalAPIs.Models;

namespace GitNode.Infrastructure.ExternalAPIs.Mappers
{
    internal class GithubMapper : IGithubMapper
    {
        public PlatformUser Map(GithubUser model) => new PlatformUser()
        {
            Id = model.id.ToString(),
            Login = model.login,
            Name = model.name,
            Url = model.html_url,
            //Email = model.email // TODO: remove
        };

        public PlatformRepository Map(GithubRepository model) => new PlatformRepository()
        {
            Id = model.id,
            Name = model.name,
            Description = model.description,
            Url = model.html_url,
            Private = model.@private
        };

        public PlatformToken Map(GithubToken model) => new PlatformToken()
        {
            AccessToken = model.access_token
        };
    }
}

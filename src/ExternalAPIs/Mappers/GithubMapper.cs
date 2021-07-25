using GitNode.Application.Common.Models;
using GitNode.ExternalAPIs.Interfaces;
using GitNode.ExternalAPIs.Models;

namespace GitNode.ExternalAPIs.Mappers
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

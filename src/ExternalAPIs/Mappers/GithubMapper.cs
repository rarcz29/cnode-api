using CNode.Application.Common.Models;
using CNode.ExternalAPIs.Interfaces;
using CNode.ExternalAPIs.Models;

namespace CNode.ExternalAPIs.Mappers
{
    internal class GithubMapper : IGithubMapper
    {
        public PlatformUser Map(GithubUser model) => new()
        {
            Id = model.id.ToString(),
            Login = model.login,
            Name = model.name,
            Url = model.html_url,
            //Email = model.email // TODO: remove
        };

        public PlatformRepository Map(GithubRepository model) => new()
        {
            Id = model.id,
            Name = model.name,
            Description = model.description,
            Url = model.html_url,
            Private = model.@private
        };

        public PlatformToken Map(GithubToken model) => new()
        {
            AccessToken = model.access_token
        };
    }
}

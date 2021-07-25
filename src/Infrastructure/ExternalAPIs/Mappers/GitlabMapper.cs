using GitNode.Application.Common.Models;
using GitNode.Infrastructure.ExternalAPIs.Interfaces;
using GitNode.Infrastructure.ExternalAPIs.Models;

namespace GitNode.Infrastructure.ExternalAPIs.Mappers
{
    internal class GitlabMapper : IGitlabMapper
    {
        public PlatformRepository Map(GitlabRepository model) => new PlatformRepository()
        {
            Id = model.id,
            Name = model.path,
            Description = model.description,
            Url = model.web_url,
            Private = model.visibility == "private"
        };

        public PlatformToken Map(GitlabToken model) => new PlatformToken()
        {
            AccessToken = model.access_token
        };

        public PlatformUser Map(GitlabUser model) => new PlatformUser()
        {
            Id = model.id.ToString(),
            Login = model.username,
            Name = model.name,
            Url = model.web_url,
        };
    }
}

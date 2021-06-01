using CNode.Application.Common.Models;
using CNode.ExternalAPIs.Interfaces;
using CNode.ExternalAPIs.Models;

namespace CNode.ExternalAPIs.Mappers
{
    internal class GitlabMapper : IGitlabMapper
    {
        public PlatformRepository Map(GitlabRepository model) => new()
        {
            Id = model.id,
            Name = model.path,
            Description = model.description,
            Url = model.web_url,
            Private = model.visibility == "private"
        };

        public PlatformToken Map(GitlabToken model) => new()
        {
            AccessToken = model.access_token
        };

        public PlatformUser Map(GitlabUser model) => new()
        {
            Id = model.id.ToString(),
            Login = model.username,
            Name = model.name,
            Url = model.web_url,
        };
    }
}

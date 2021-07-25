using GitNode.Domain.Platforms;
using GitNode.Infrastructure.ExternalAPIs.Models;

namespace GitNode.Infrastructure.ExternalAPIs.Interfaces
{
    internal interface IGithubMapper
    {
        PlatformRepository Map(GithubRepository model);
        PlatformToken Map(GithubToken model);
        PlatformUser Map(GithubUser model);
    }
}
using GitNode.Application.Common.Models;
using GitNode.ExternalAPIs.Models;

namespace GitNode.ExternalAPIs.Interfaces
{
    internal interface IGithubMapper
    {
        PlatformRepository Map(GithubRepository model);
        PlatformToken Map(GithubToken model);
        PlatformUser Map(GithubUser model);
    }
}
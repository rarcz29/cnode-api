using CNode.Application.Common.Models;
using CNode.ExternalAPIs.Models;

namespace CNode.ExternalAPIs.Interfaces
{
    internal interface IGithubMapper
    {
        PlatformRepository Map(GithubRepository model);
        PlatformToken Map(GithubToken model);
        PlatformUser Map(GithubUser model);
    }
}
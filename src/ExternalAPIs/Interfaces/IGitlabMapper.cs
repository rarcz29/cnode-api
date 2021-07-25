using GitNode.Application.Common.Models;
using GitNode.ExternalAPIs.Models;

namespace GitNode.ExternalAPIs.Interfaces
{
    internal interface IGitlabMapper
    {
        PlatformRepository Map(GitlabRepository model);
        PlatformToken Map(GitlabToken model);
        PlatformUser Map(GitlabUser model);
    }
}

using GitNode.Application.Common.Models;
using GitNode.Infrastructure.ExternalAPIs.Models;

namespace GitNode.Infrastructure.ExternalAPIs.Interfaces
{
    internal interface IGitlabMapper
    {
        PlatformRepository Map(GitlabRepository model);
        PlatformToken Map(GitlabToken model);
        PlatformUser Map(GitlabUser model);
    }
}

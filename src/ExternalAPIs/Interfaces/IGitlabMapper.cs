using CNode.Application.Common.Models;
using CNode.ExternalAPIs.Models;

namespace CNode.ExternalAPIs.Interfaces
{
    internal interface IGitlabMapper
    {
        PlatformRepository Map(GitlabRepository model);
        PlatformToken Map(GitlabToken model);
        PlatformUser Map(GitlabUser model);
    }
}

using CNode.Application.Common.Data.ExternalAPIs.GitHub;

namespace CNode.Application.Common.Data.ExternalAPIs
{
    public interface IPlatformProvider
    {
        IUserProcessor Users { get; }

        IRepoProcessor Repositories { get; }
    }
}

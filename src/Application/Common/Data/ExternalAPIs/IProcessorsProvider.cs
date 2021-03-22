using CNode.Application.Common.Data.ExternalAPIs.GitHub;

namespace CNode.Application.Common.Data.ExternalAPIs
{
    public interface IProcessorsProvider
    {
        IUserProcessor Users { get; }
    }
}

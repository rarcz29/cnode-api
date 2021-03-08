using CNode.Application.Data.ExternalAPIs.GitHub;

namespace CNode.Application.Data.ExternalAPIs
{
    public interface IProcessorsProvider
    {
        IUserProcessor Users { get; }
    }
}

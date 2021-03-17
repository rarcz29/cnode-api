using CNode.Application.Common.Data.ExternalAPIs.GitHub;

namespace CNode.Application.Common.Data.ExternalAPIs
{
    public interface IProcessorsProvider
    {
        IAccountProcessor Account { get; }

        IUserProcessor Users { get; }
    }
}

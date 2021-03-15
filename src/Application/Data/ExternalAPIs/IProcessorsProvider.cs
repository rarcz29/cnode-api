using CNode.Application.Data.ExternalAPIs.GitHub;

namespace CNode.Application.Data.ExternalAPIs
{
    public interface IProcessorsProvider
    {
        IAccountProcessor Account { get; }

        IUserProcessor Users { get; }
    }
}

using System.Threading.Tasks;

namespace CNode.Application.Common.Data.ExternalAPIs.GitHub
{
    public interface IRepoProcessor
    {
        Task CreateNewRepoAsync(string reponame, string description, string token);
    }
}

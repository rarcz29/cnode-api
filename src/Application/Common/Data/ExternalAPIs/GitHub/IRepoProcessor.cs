using CNode.Application.Common.Models;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.ExternalAPIs.GitHub
{
    public interface IRepoProcessor
    {
        Task<PlatformRepository> CreateNewRepoAsync(string reponame, string description, string token);
    }
}

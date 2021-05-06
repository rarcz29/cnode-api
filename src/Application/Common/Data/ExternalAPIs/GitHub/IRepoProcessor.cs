using CNode.Domain.Models;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.ExternalAPIs.GitHub
{
    public interface IRepoProcessor
    {
        Task<GitRepository> CreateNewRepoAsync(string reponame, string description, string token);
    }
}

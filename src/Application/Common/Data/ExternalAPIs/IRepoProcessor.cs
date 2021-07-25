using System.Threading.Tasks;
using GitNode.Application.Common.Models;

namespace GitNode.Application.Common.Data.ExternalAPIs
{
    public interface IRepoProcessor
    {
        Task<PlatformRepository> CreateNewRepoAsync(string reponame, string description, bool isPrivate, string token);
    }
}

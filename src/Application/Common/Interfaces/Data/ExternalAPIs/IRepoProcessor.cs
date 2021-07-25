using System.Threading.Tasks;
using GitNode.Domain.Platforms;

namespace GitNode.Application.Common.Interfaces.Data.ExternalAPIs
{
    public interface IRepoProcessor
    {
        Task<PlatformRepository> CreateNewRepoAsync(string reponame, string description, bool isPrivate, string token);
    }
}

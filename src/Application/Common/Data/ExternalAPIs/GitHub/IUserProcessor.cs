using CNode.Domain.Models;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.ExternalAPIs.GitHub
{
    public interface IUserProcessor
    {
        Task<GitUser> GetUserAsync(string token);
    }
}

using CNode.Application.Common.Models;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.ExternalAPIs.GitHub
{
    public interface IUserProcessor
    {
        Task<PlatformUser> GetUserAsync(string token);

        Task<PlatformUser> GetUserByUsernameAsync(string username);

        Task<PlatformToken> GetTokenAsync(string code);
    }
}

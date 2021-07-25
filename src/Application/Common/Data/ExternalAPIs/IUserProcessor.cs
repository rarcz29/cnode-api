using System.Threading.Tasks;
using GitNode.Domain.Platforms;

namespace GitNode.Application.Common.Data.ExternalAPIs
{
    public interface IUserProcessor
    {
        Task<PlatformUser> GetUserAsync(string token);

        Task<PlatformUser> GetUserByUsernameAsync(string username);

        Task<PlatformToken> GetTokenAsync(string code);
    }
}

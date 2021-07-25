using System.Threading.Tasks;
using GitNode.Domain.Entities;

namespace GitNode.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<AuthenticationResult> AuthenticateAsync(string usernameOrEmail, string password);
        Task<AuthenticationResult> RefreshAsync(string token, string refreshToken);
        Task RegisterAsync(string username, string email, string password);
        Task RemoveAsync(int userId);
    }
}

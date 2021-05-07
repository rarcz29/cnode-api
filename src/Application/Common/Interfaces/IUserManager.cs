using CNode.Domain.Entities;
using System.Threading.Tasks;

namespace CNode.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<AuthenticationResult> AuthenticateAsync(string usernameOrEmail, string password);
        Task<AuthenticationResult> RefreshAsync(string token, string refreshToken);
        Task RegisterAsync(string username, string email, string password, bool twoFactorEnabled = false);
        Task RemoveAsync(int userId);
    }
}

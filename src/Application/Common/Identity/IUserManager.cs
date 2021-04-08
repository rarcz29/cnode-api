using System.Threading.Tasks;

namespace CNode.Application.Identity
{
    public interface IUserManager
    {
        Task<string> AuthenticateAsync(string username, string email, string password);
        Task RegisterAsync(string username, string email, string password, bool twoFactorEnabled = false);
        Task RemoveAsync(int userId);
    }
}

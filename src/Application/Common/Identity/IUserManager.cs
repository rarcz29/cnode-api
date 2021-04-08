using System.Threading.Tasks;

namespace CNode.Application.Identity
{
    public interface IUserManager
    {
        Task<string> Authenticate(string username, string email, string password);
        Task Register(string username, string email, string password, bool twoFactorEnabled = false);
        Task Remove(int userId);
    }
}

using CNode.Domain.Entities;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.Database.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> Get(int userId, string gitUsername, int platformId);
        Task<string> GetTokenAsync(int userId, int platformId, string gitUsername);
    }
}

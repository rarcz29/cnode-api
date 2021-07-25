using System.Threading.Tasks;
using GitNode.Domain.Entities;

namespace GitNode.Application.Common.Interfaces.Data.Database.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> Get(int userId, string gitUsername, int platformId);
        Task<string> GetTokenAsync(int userId, int platformId, string gitUsername);
    }
}

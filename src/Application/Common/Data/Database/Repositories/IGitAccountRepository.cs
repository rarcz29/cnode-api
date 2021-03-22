using CNode.Domain.Entities;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.Database.Repositories
{
    public interface IGitAccountRepository : IRepository<GitAccount>
    {
        Task<string> GetTokenAsync(int userId, int gitToolId, int gitUserId);
    }
}

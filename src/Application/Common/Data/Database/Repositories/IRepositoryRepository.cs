using CNode.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.Database.Repositories
{
    public interface IRepositoryRepository : IRepository<Repository>
    {
        Task<IEnumerable<Repository>> GetRepositoriesFullAsync(int accountId);
    }
}

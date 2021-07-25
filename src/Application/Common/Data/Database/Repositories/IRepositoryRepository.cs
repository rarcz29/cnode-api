using System.Collections.Generic;
using System.Threading.Tasks;
using GitNode.Domain.Entities;

namespace GitNode.Application.Common.Data.Database.Repositories
{
    public interface IRepositoryRepository : IRepository<Repository>
    {
        Task<IEnumerable<Repository>> GetRepositoriesFullAsync(int accountId);
    }
}

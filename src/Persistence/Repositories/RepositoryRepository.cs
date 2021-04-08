using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;

namespace CNode.Persistence.Repositories
{
    internal class RepositoryRepository : Repository<Repository>, IRepositoryRepository
    {
        public RepositoryRepository(AppDbContext db) : base(db)
        {

        }
    }
}

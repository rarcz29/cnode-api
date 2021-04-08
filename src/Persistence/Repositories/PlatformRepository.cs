using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;

namespace CNode.Persistence.Repositories
{
    internal class PlatformRepository : Repository<Platform>, IPlatformRepository
    {
        public PlatformRepository(AppDbContext db) : base(db)
        {

        }
    }
}

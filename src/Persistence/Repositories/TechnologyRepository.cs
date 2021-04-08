using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;

namespace CNode.Persistence.Repositories
{
    internal class TechnologyRepository : Repository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(AppDbContext db) : base(db)
        {

        }
    }
}

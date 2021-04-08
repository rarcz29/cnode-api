using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;

namespace CNode.Persistence.Repositories
{
    internal class TechnologyTypeRepository : Repository<TechnologyType>, ITechnologyTypeRepository
    {
        public TechnologyTypeRepository(AppDbContext db) : base(db)
        {

        }
    }
}

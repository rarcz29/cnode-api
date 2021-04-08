using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CNode.Persistence.Repositories
{
    internal class PlatformRepository : Repository<Platform>, IPlatformRepository
    {
        private readonly AppDbContext _db;

        public PlatformRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Platform> GetByNameAsync(string name)
        {
            return await _db.Platforms.Where(t => t.Name == name).FirstOrDefaultAsync();
        }
    }
}

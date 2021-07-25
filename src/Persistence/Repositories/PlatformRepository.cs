using System.Linq;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces.Data.Database.Repositories;
using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence.Repositories
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
            return await _db.Platforms.Where(t => t.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }
    }
}

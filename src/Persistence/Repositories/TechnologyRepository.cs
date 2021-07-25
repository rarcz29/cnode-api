using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitNode.Application.Common.Data.Database.Repositories;
using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence.Repositories
{
    internal class TechnologyRepository : Repository<Technology>, ITechnologyRepository
    {
        private readonly AppDbContext _db;

        public TechnologyRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Technology>> FindTechologiesAsync(string pattern)
        {
            var lower = pattern != null ? pattern.ToLower() : "";
            return await _db.Technologies.Where(x => x.Name.ToLower().Contains(lower)).ToListAsync();
        }

        public async Task<IEnumerable<Technology>> GetTechnologiesAsync(IEnumerable<string> technologies)
        {
            // TODO: case sensitive
            return technologies != null
                ? await _db.Technologies.Where(x => technologies.Contains(x.Name)).ToListAsync()
                : null;
        }
    }
}

using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNode.Persistence.Repositories
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
            var x = await _db.Technologies.Where(x => x.Name.ToLower().Contains(lower)).ToListAsync();
            return x;
        }
    }
}

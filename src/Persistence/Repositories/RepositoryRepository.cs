using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitNode.Application.Common.Data.Database.Repositories;
using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence.Repositories
{
    internal class RepositoryRepository : Repository<Repository>, IRepositoryRepository
    {
        private readonly AppDbContext _db;

        public RepositoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Repository>> GetRepositoriesFullAsync(int accountId)
        {
            return await _db.Repositories.Where(r => r.AccountId == accountId).Include(r => r.Technologies).ToListAsync();
        }
    }
}

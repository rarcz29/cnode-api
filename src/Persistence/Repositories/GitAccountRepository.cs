using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CNode.Persistence.Repositories
{
    internal class GitAccountRepository : Repository<GitAccount>, IGitAccountRepository
    {
        private readonly AppDbContext _db;

        public GitAccountRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<string> GetTokenAsync(int userId, int gitToolId, int gitUserId)
        {
            return await _db.GitAccounts.Where(a => a.UserId == userId && a.GitToolId == gitToolId && a.GitUserId == gitUserId)
                                        .Select(a => a.Token)
                                        .FirstOrDefaultAsync();
        }
    }
}

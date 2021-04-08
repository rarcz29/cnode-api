using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CNode.Persistence.Repositories
{
    internal class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly AppDbContext _db;

        public AccountRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<string> GetTokenAsync(int userId, int platformId, string gitUsername)
        {
            return await _db.Accounts.Where(a => a.UserId == userId && a.PlatformId == platformId && a.Username == gitUsername)
                                     .Select(a => a.Token)
                                     .FirstOrDefaultAsync();
        }
    }
}

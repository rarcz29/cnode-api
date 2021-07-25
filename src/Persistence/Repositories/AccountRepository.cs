using System.Linq;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces.Data.Database.Repositories;
using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence.Repositories
{
    internal class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly AppDbContext _db;

        public AccountRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Account> Get(int userId, string gitUsername, int platformId)
        {
            return await _db.Accounts.Where(x => x.Username == gitUsername
                                                 && x.UserId == userId
                                                 && x.PlatformId == platformId).FirstOrDefaultAsync();
        }

        public async Task<string> GetTokenAsync(int userId, int platformId, string gitUsername)
        {
            return await _db.Accounts.Where(a => a.UserId == userId && a.PlatformId == platformId && a.Username == gitUsername)
                                     .Select(a => a.Token)
                                     .FirstOrDefaultAsync();
        }
    }
}

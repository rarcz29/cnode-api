using System.Linq;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces.Data.Database.Repositories;
using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence.Repositories
{
    internal class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly AppDbContext _db;

        public RefreshTokenRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<RefreshToken> GetByToken(string token)
        {
            return await _db.RefreshTokens.Where(x => x.Token == token).FirstOrDefaultAsync();
        }
    }
}

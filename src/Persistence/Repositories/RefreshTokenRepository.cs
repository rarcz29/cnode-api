using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CNode.Persistence.Repositories
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

using System.Threading.Tasks;
using GitNode.Domain.Entities;

namespace GitNode.Application.Common.Interfaces.Data.Database.Repositories
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        Task<RefreshToken> GetByToken(string token);
    }
}

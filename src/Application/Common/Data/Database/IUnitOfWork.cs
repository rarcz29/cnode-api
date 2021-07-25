using System;
using System.Threading.Tasks;
using GitNode.Application.Common.Data.Database.Repositories;

namespace GitNode.Application.Common.Data.Database
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IPlatformRepository Platforms { get; }
        IRepositoryRepository Repositories { get; }
        ITechnologyRepository Technologies { get; }
        IUserRepository Users { get; }
        IRefreshTokenRepository RefreshTokens { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

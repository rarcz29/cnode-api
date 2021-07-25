using System.Threading.Tasks;
using GitNode.Application.Common.Data.Database;
using GitNode.Application.Common.Data.Database.Repositories;
using GitNode.Persistence.Repositories;

namespace GitNode.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Accounts ??= new AccountRepository(db);
            Platforms ??= new PlatformRepository(db);
            Repositories ??= new RepositoryRepository(db);
            Technologies ??= new TechnologyRepository(db);
            Users ??= new UserRepository(db);
            RefreshTokens ??= new RefreshTokenRepository(db);
        }

        public IAccountRepository Accounts { get; }
        public IPlatformRepository Platforms { get; }
        public IRepositoryRepository Repositories { get; }
        public ITechnologyRepository Technologies { get; }
        public IUserRepository Users { get; }
        public IRefreshTokenRepository RefreshTokens { get; }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}

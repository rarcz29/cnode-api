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

        public IAccountRepository Accounts { get; private set; }
        public IPlatformRepository Platforms { get; private set; }
        public IRepositoryRepository Repositories { get; private set; }
        public ITechnologyRepository Technologies { get; private set; }
        public IUserRepository Users { get; private set; }
        public IRefreshTokenRepository RefreshTokens { get; private set; }

        public int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}

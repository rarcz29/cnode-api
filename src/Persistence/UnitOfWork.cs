using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Data.Database.Repositories;
using CNode.Persistence.Repositories;
using System.Threading.Tasks;

namespace CNode.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            GitAccounts ??= new GitAccountRepository(db);
            GitTools ??= new GitToolRepository(db);
        }

        public IGitAccountRepository GitAccounts { get; private set; }

        public IGitToolRepository GitTools { get; private set; }

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

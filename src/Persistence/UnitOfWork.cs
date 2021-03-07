using CNode.Application.Data.Database;
using System.Threading.Tasks;

namespace CNode.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        public int Commit()
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

        public async Task<int> CommitAsync()
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

using System;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.Database
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

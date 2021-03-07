using System;
using System.Threading.Tasks;

namespace CNode.Application.Data.Database
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        Task<int> CommitAsync();
    }
}

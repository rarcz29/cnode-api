using CNode.Application.Common.Data.Database.Repositories;
using System;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.Database
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IPlatformRepository Platforms { get; }
        IRepositoryRepository Repositories { get; }
        ITechnologyRepository Technologies { get; }
        ITechnologyTypeRepository TechnologyTypes { get; }
        IUserRepository Users { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

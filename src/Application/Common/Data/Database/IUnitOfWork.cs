using CNode.Application.Common.Data.Database.Repositories;
using System;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.Database
{
    public interface IUnitOfWork : IDisposable
    {
        public IGitAccountRepository GitAccounts { get; }

        public IGitToolRepository GitTools { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

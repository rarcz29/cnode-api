using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;

namespace CNode.Persistence.Repositories
{
    internal class GitAccountRepository : Repository<GitAccount>, IGitAccountRepository
    {
        public GitAccountRepository(AppDbContext db) : base(db) { }
    }
}

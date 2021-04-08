using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;

namespace CNode.Persistence.Repositories
{
    internal class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext db) : base(db)
        {

        }
    }
}

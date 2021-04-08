using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;

namespace CNode.Persistence.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext db) : base(db)
        {

        }
    }
}

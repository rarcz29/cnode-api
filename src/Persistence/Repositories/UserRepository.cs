using GitNode.Application.Common.Data.Database.Repositories;
using GitNode.Domain.Entities;

namespace GitNode.Persistence.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext db) : base(db)
        {

        }
    }
}

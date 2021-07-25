using System.Threading.Tasks;
using GitNode.Domain.Entities;

namespace GitNode.Application.Common.Data.Database.Repositories
{
    public interface IPlatformRepository : IRepository<Platform>
    {
        Task<Platform> GetByNameAsync(string name);
    }
}

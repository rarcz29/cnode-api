using CNode.Domain.Entities;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.Database.Repositories
{
    public interface IPlatformRepository : IRepository<Platform>
    {
        Task<Platform> GetByNameAsync(string name);
    }
}

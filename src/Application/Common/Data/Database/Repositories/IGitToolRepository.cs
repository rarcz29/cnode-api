using CNode.Domain.Entities;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.Database.Repositories
{
    public interface IGitToolRepository : IRepository<GitTool>
    {
        Task<GitTool> GetByNameAsync(string name);
    }
}

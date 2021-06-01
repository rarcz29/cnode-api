using CNode.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CNode.Application.Common.Data.Database.Repositories
{
    public interface ITechnologyRepository : IRepository<Technology>
    {
        Task<IEnumerable<Technology>> FindTechologiesAsync(string pattern);
        Task<IEnumerable<Technology>> GetTechnologiesAsync(IEnumerable<string> technologies);
    }
}

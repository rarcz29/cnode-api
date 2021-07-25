using System.Collections.Generic;
using System.Threading.Tasks;
using GitNode.Domain.Entities;

namespace GitNode.Application.Common.Data.Database.Repositories
{
    public interface ITechnologyRepository : IRepository<Technology>
    {
        Task<IEnumerable<Technology>> FindTechologiesAsync(string pattern);
        Task<IEnumerable<Technology>> GetTechnologiesAsync(IEnumerable<string> technologies);
    }
}

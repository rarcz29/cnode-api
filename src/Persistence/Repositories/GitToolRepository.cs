using CNode.Application.Common.Data.Database.Repositories;
using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CNode.Persistence.Repositories
{
    class GitToolRepository : Repository<GitTool>, IGitToolRepository
    {
        private readonly AppDbContext _db;

        public GitToolRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<GitTool> GetByNameAsync(string name)
        {
            return await _db.GitTools.Where(t => t.Name == name).FirstOrDefaultAsync();
        }
    }
}

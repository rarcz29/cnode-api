using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CNode.Persistence
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<TechnologyType> TechnologyTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());
            base.OnModelCreating(builder);
        }
    }
}

using System.Reflection;
using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}

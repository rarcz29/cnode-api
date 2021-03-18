using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CNode.Persistence
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<GitAccount> GitAccounts { get; set; }

        public DbSet<GitTool> GitTools { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}

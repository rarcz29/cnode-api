using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNode.Persistence.Configurations
{
    internal class GitAccountConfiguration : IEntityTypeConfiguration<GitAccount>
    {
        public void Configure(EntityTypeBuilder<GitAccount> builder)
        {
            builder
                .Property(a => a.UserId)
                .IsRequired();

            builder
                .Property(ga => ga.GitUserId)
                .IsRequired();

            builder
                .Property(a => a.Token)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(a => a.GitToolId)
                .IsRequired();

            builder
                .HasIndex(a => new { a.GitUserId, a.GitToolId })
                .IsUnique();
        }
    }
}

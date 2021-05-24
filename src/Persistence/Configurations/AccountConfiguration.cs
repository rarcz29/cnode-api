using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNode.Persistence.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .Property(a => a.OriginId)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .Property(a => a.OriginUrl)
                .IsRequired();

            builder
                .Property(a => a.Username)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(a => a.Token)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .Property(a => a.UserId)
                .IsRequired();

            builder
                .Property(a => a.PlatformId)
                .IsRequired();

            builder
                .HasIndex(a => new { a.OriginId, a.PlatformId })
                .IsUnique();

            builder
                .HasIndex(a => new { a.Username, a.PlatformId })
                .IsUnique();

            builder
                .HasIndex(a => new { a.Token, a.PlatformId })
                .IsUnique();
        }
    }
}

using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNode.Persistence.Configurations
{
    internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder
                .Property(r => r.Token)
                .IsRequired();

            builder
                .Property(r => r.JwtId)
                .IsRequired();

            builder
                .HasIndex(r => r.Token)
                .IsUnique();
        }
    }
}

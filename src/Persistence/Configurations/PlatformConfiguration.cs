using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitNode.Persistence.Configurations
{
    internal class PlatformConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}

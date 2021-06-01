using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNode.Persistence.Configurations
{
    internal class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder
                .Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}

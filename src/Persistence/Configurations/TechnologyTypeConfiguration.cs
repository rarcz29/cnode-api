using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNode.Persistence.Configurations
{
    internal class TechnologyTypeConfigurationv : IEntityTypeConfiguration<TechnologyType>
    {
        public void Configure(EntityTypeBuilder<TechnologyType> builder)
        {
            builder
                .Property(t => t.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(t => t.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder
                .HasIndex(t => t.Name)
                .IsUnique();

            builder
                .HasIndex(t => t.NamePlural)
                .IsUnique();
        }
    }
}

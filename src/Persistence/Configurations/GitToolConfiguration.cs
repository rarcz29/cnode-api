using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNode.Persistence.Configurations
{
    internal class GitToolConfiguration : IEntityTypeConfiguration<GitTool>
    {
        public void Configure(EntityTypeBuilder<GitTool> builder)
        {
            builder
                .Property(t => t.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}

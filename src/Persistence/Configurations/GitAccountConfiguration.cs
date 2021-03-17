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
                .Property(ga => ga.UserId)
                .IsRequired();

            builder
                .Property(ga => ga.Token)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

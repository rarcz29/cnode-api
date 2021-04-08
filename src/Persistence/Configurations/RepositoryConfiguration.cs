using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNode.Persistence.Configurations
{
    internal class RepositoryConfiguration : IEntityTypeConfiguration<Repository>
    {
        public void Configure(EntityTypeBuilder<Repository> builder)
        {
            builder
                .Property(r => r.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(r => r.Description)
                .HasMaxLength(200);

            builder
                .Property(r => r.Private)
                .IsRequired();

            builder
                .Property(r => r.Share)
                .IsRequired();

            builder
                .Property(r => r.OriginId)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(r => r.OriginName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(r => r.OriginUrl)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(r => r.AccountId)
                .IsRequired();
        }
    }
}

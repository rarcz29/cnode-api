using CNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNode.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.Username)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasMaxLength(65)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.TwoFactorEnabled)
                .IsRequired();

            builder
                .Property(u => u.CreatedAt)
                .IsRequired();
        }
    }
}

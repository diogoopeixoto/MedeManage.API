using MediManage.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediManage.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(u => u.BirthDate)
                .IsRequired();

            builder
                .Property(u => u.CreatedAt)
                .IsRequired();

            builder
                .Property(u => u.Active)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(50);
                        
        }
    }
}

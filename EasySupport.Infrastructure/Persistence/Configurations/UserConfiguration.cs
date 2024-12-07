using EasySupport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySupport.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(e => e.Enterprise)
                .WithMany()
                .HasForeignKey(e => e.EnterpriseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(d => d.Department)
                .WithMany()
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

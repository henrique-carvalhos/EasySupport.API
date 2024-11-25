using EasySupport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySupport.Infrastructure.Persistence.Configurations
{
    public class OriginServiceConfiguration : IEntityTypeConfiguration<OriginService>
    {
        public void Configure(EntityTypeBuilder<OriginService> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}

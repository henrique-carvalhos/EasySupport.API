using EasySupport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySupport.Infrastructure.Persistence.Configurations
{
    public class StatusTicketConfiguration : IEntityTypeConfiguration<StatusTicket>
    {
        public void Configure(EntityTypeBuilder<StatusTicket> builder)
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

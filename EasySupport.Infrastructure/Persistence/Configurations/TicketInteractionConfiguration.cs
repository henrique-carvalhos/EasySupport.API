using EasySupport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySupport.Infrastructure.Persistence.Configurations
{
    public class TicketInteractionConfiguration : IEntityTypeConfiguration<TicketInteraction>
    {
        public void Configure(EntityTypeBuilder<TicketInteraction> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .HasOne(t => t.Ticket)
                .WithMany(t => t.Interactions)
                .HasForeignKey(t => t.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(t => t.Attendant)
                .WithMany()
                .HasForeignKey(t => t.AttendantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(st => st.StatusTicket)
                .WithMany()
                .HasForeignKey(st => st.StatusTicktId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

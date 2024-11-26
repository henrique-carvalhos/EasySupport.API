using EasySupport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySupport.Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255);


            builder
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(s => s.Subcategory)
                .WithMany()
                .HasForeignKey(p => p.SubcategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.StatusTicket)
                .WithMany()
                .HasForeignKey(t =>  t.StatusTicketId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Client)
                .WithMany()
                .HasForeignKey(u => u.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Interactions)
               .WithOne(t => t.Ticket)
               .HasForeignKey(t => t.TicketId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

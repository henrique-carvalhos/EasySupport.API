using EasySupport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySupport.Infrastructure.Persistence.Configurations
{
    public class SolutionTicketConfiguration : IEntityTypeConfiguration<SolutionTicket>
    {
        public void Configure(EntityTypeBuilder<SolutionTicket> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}

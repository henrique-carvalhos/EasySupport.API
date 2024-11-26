using EasySupport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySupport.Infrastructure.Persistence.Configurations
{
    public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.
                HasKey(i => i.Id);

            builder
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

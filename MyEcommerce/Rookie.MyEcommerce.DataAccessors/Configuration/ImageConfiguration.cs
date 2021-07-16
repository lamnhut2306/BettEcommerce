using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Entities.ProductAggregate;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(p => p.Position)
                .IsRequired();
            builder.Property(p => p.Uri)
                .IsRequired();
        }
    }
}

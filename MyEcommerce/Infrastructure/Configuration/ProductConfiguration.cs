using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Entities.ProductAggregate;
using Rookie.MyEcommerce.Contracts.Constants;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //key
            builder.HasKey(p => p.Id);

            //relationship
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            builder.HasMany(p => p.ProductRatings).WithOne(pr => pr.Product).HasForeignKey(pr => pr.ProductId);
            builder.HasMany(p => p.OrderItems).WithOne(oi => oi.Product).HasForeignKey(oi => oi.ProductId);
            builder.HasOne(p => p.FirstImage).WithOne();
            builder.HasMany(p => p.Images).WithOne();

            //properties
            builder.Property(p => p.Description).IsRequired().HasMaxLength(ValidationRules.ProductRules.MaxLengthCharactersForDescription);
            builder.Property(p => p.Discount).HasDefaultValue(ValidationRules.CommonRules.DefaultValueForDiscount);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(ValidationRules.ProductRules.MaxLengthCharactersForProductName);
            builder.Property(p => p.UnitPrice).IsRequired().HasColumnType("money");
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.FirstImageId).IsRequired();
        }
    }
}

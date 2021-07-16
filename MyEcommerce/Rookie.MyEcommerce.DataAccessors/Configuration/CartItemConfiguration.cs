using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Entities.CartAggregate;
using Rookie.MyEcommerce.Entities.ProductAggregate;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.HasOne(ci => ci.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ci => ci.Cart)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ci => ci.ProductId)
                .IsRequired();
            builder.Property(ci => ci.CartId)
                .IsRequired();
            builder.Property(ci => ci.UnitPrice)
                .HasColumnType("money");
            builder.Property(ci => ci.Quantity)
                .HasDefaultValue(1);
        }
    }
}

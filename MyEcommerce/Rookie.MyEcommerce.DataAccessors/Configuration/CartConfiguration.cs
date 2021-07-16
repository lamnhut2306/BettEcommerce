using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Entities.CartAggregate;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(c => c.CartId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(c => c.CustomerId)
                .IsRequired();
        }
    }
}

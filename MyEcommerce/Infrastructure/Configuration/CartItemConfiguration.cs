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
        }
    }
}

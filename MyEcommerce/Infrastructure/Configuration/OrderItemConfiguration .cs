using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Contracts.Constants;
using Rookie.MyEcommerce.Entities.OrderAggregate;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.OrderId);

            builder.HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            builder.Property(oi => oi.Quantity)
                .HasDefaultValue(ValidationRules.OrderItemRules.DefaultValueForQuantity);
            builder.Property(oi => oi.UnitPrice)
                .IsRequired()
                .HasColumnType("money");
            builder.Property(oi => oi.OrderId)
                .IsRequired();
            builder.Property(oi => oi.ProductId)
                .IsRequired();
        }
    }
}

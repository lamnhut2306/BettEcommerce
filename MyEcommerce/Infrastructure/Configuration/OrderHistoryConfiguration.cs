using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Contracts.Constants;
using Rookie.MyEcommerce.Entities.OrderAggregate;
using System;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.HasKey(oh => oh.Id);

            builder.HasOne(oh => oh.Order)
                .WithMany(o => o.OrderHistories)
                .HasForeignKey(oh => oh.OrderId);

            builder.HasOne(oh => oh.OrderStatus)
                .WithMany(os => os.OrderHistories)
                .HasForeignKey(oh => oh.OrderStatusId);

            builder.Property(p => p.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Note).HasDefaultValue(ValidationRules.CommonRules.MaxLengthCharactersForText);
        }
    }
}

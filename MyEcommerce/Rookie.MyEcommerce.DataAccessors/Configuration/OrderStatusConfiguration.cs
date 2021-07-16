using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Contracts.Constants;
using Rookie.MyEcommerce.Entities.OrderAggregate;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(os => os.Id);

            builder.HasMany(os => os.OrderHistories)
                .WithOne(oh => oh.OrderStatus)
                .HasForeignKey(oh => oh.OrderStatusId);

            builder.Property(os => os.Id).ValueGeneratedOnAdd();
            builder.Property(os => os.Status)
                .HasMaxLength(ValidationRules.CommonRules.MaxLengthCharactersForShortText)
                .IsRequired();
            builder.Property(os => os.Description)
                .HasMaxLength(ValidationRules.CommonRules.MaxLengthCharactersForText);

            builder.HasData(
                new List<OrderStatus>()
                {
                    new OrderStatus() { Id = System.Guid.NewGuid(), Status = "Tạo mới", Description = "Khách hàng tạo mới đơn hàng."},
                    new OrderStatus() { Id = System.Guid.NewGuid(), Status = "Xác nhận", Description = "Đơn hàng được xác nhận."},
                    new OrderStatus() { Id = System.Guid.NewGuid(), Status = "Đang vận chuyển", Description = "Đơn hàng đã chuyển giao cho đơn vị vận chuyển."},
                    new OrderStatus() { Id = System.Guid.NewGuid(), Status = "Thành công", Description = "Khách hàng đã nhận và thanh toán đơn hàng."},
                    new OrderStatus() { Id = System.Guid.NewGuid(), Status = "Hủy", Description = "Đơn hàng bị hủy."},
                });
        }
    }
}

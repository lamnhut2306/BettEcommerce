using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Entities.OrderAggregate;
using Rookie.MyEcommerce.Contracts.Constants;
using System;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.OrderHistories)
                .WithOne(oh => oh.Order)
                .HasForeignKey(oh => oh.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();

                a.Property(a => a.Detail)
                    .HasMaxLength(ValidationRules.CommonRules.MaxLengthCharactersForText)
                    .IsRequired();
                a.Property(a => a.District)
                    .HasMaxLength(ValidationRules.CommonRules.MaxLengthCharactersForText)
                    .IsRequired();
                a.Property(a => a.Province)
                    .HasMaxLength(ValidationRules.CommonRules.MaxLengthCharactersForText)
                    .IsRequired();
            });

            builder.Property(o => o.Message)
                .HasMaxLength(ValidationRules.CommonRules.MaxLengthCharactersForText);
            builder.Property(o => o.PhoneNumber)
                .HasMaxLength(ValidationRules.OrderRules.ExactLengthForPhoneNumber)
                .IsFixedLength();
            builder.Property(o => o.CustomerName)
                .HasMaxLength(ValidationRules.CommonRules.MaxLengthCharactersForText);
            builder.Property(o => o.SubscriptionDate).HasDefaultValue(DateTime.Now);
            builder.Property(o => o.Total).HasColumnType("money");
        }
    }
}

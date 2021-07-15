using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Contracts.Constants;
using Rookie.MyEcommerce.Entities.ProductAggregate;
using System;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    public class ProductRatingConfiguration : IEntityTypeConfiguration<ProductRating>
    {
        public void Configure(EntityTypeBuilder<ProductRating> builder)
        {
            builder.HasKey(pr => pr.Id);

            builder.HasOne(pr => pr.Product)
                .WithMany(p => p.ProductRatings)
                .HasForeignKey(pr => pr.ProductId);
            builder.HasMany(pr => pr.Images)
                .WithOne();
            builder.HasOne(pr => pr.Product)
                .WithMany(p => p.ProductRatings)
                .HasForeignKey(pr => pr.ProductId);

            builder.Property(pr => pr.Rating)
                .IsRequired();
            builder.Property(pr => pr.Comment)
                .IsRequired()
                .HasMaxLength(ValidationRules.ProductRatingRules.MaxLengthCharactersForComment);
            builder.Property(pr => pr.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            builder.Property(pr => pr.IsBoughtCreator)
                .HasDefaultValue(false);
            builder.Property(pr => pr.ProductId)
                .IsRequired();
            builder.Property(pr => pr.CreatorName)
                .IsRequired()
                .HasMaxLength(ValidationRules.CommonRules.MaxLengthCharactersForShortText);
        }
    }
}

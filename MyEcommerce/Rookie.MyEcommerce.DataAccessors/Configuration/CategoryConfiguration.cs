using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.MyEcommerce.Contracts.Constants;
using Rookie.MyEcommerce.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.DataAccessors.Configuration
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(ValidationRules.CategoryRules.MaxLengthCharatersForName);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(ValidationRules.CategoryRules.MaxLengthCharatersForDescription);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}

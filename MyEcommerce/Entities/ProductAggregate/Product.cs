using Rookie.MyEcommerce.Entities.OrderAggregate;
using System;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.Entities.ProductAggregate
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public byte Discount { get; set; }
        public Guid FirstImageId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; private set; }
        public virtual Image FirstImage { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<ProductRating> ProductRatings { get; private set; }
        public virtual ICollection<OrderItem> OrderItems { get; private set; }
    }
}

using System;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.Entities.ProductAggregate
{
    public class ProductRating : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid CreatorId { get; set; }
        public string CreatorName { get; set; }
        public byte Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsBoughtCreator { get; set; }
        public virtual Product Product { get; private set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}

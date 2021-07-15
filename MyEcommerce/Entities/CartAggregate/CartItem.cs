using Rookie.MyEcommerce.Entities.ProductAggregate;
using System;

namespace Rookie.MyEcommerce.Entities.CartAggregate
{
    public class CartItem : BaseEntity
    {
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public virtual Product Product { get; private set; }
        public virtual Cart Cart { get; private set; }
    }
}

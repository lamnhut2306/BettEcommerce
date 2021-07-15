using System;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.Entities.CartAggregate
{
    public class Cart : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}

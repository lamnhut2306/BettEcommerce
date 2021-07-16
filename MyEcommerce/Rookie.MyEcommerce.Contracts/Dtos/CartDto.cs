using System;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.Contracts.Dtos
{
    public class CartDto
    {
        public Guid Id;
        public Guid CustomerId { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }
    }
}

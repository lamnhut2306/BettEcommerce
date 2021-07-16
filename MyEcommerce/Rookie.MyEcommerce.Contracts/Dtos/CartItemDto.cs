using System;

namespace Rookie.MyEcommerce.Contracts.Dtos
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public virtual ProductDto Product { get; private set; }
    }
}

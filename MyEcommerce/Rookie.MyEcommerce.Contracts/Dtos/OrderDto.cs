using System;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.Contracts.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        public string Message { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public AddressDto Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<OrderItemDto> OrderItems { get; set; }
        public virtual IEnumerable<OrderHistoryDto> OrderHistories { get; set; }
    }
}

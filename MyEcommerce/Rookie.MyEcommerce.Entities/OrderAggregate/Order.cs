using System;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        public string Message { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}

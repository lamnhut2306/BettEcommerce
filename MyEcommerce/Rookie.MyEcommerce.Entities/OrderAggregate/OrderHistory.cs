using System;

namespace Rookie.MyEcommerce.Entities.OrderAggregate
{
    public class OrderHistory : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid OrderStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; }
        public virtual Order Order { get; private set; }
        public virtual OrderStatus OrderStatus { get; private set; }
    }
}

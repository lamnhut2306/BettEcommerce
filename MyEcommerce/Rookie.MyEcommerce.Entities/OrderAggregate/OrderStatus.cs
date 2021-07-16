using System.Collections.Generic;

namespace Rookie.MyEcommerce.Entities.OrderAggregate
{
    public class OrderStatus : BaseEntity
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}

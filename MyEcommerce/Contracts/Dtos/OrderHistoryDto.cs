using System;

namespace Rookie.MyEcommerce.Contracts.Dtos
{
    public class OrderHistoryDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid OrderStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; }
    }
}

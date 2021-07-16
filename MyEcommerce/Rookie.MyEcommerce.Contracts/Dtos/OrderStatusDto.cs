using System;

namespace Rookie.MyEcommerce.Contracts.Dtos
{
    public class OrderStatusDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.Contracts.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public byte Discount { get; set; }
        public List<ImageDto> Images { get; set; }
    }
}

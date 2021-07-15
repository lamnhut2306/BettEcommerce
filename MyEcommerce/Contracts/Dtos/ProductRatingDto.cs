using System;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.Contracts.Dtos
{
    public class ProductRatingDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CreatorId { get; set; }
        public string CreatorName { get; set; }
        public byte Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsBoughtCreator { get; set; }
        public virtual List<ImageDto> Images { get; set; }
    }
}

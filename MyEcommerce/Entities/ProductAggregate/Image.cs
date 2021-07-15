using System;

namespace Rookie.MyEcommerce.Entities.ProductAggregate
{
    public class Image : BaseEntity
    {
        public Guid ReferenceId { get; set; }
        public string Uri { get; set; }
    }
}

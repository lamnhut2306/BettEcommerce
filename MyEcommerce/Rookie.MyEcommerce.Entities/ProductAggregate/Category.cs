﻿using System;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.Entities.ProductAggregate
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

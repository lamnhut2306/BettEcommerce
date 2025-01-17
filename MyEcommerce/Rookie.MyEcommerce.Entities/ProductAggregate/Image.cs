﻿using System;

namespace Rookie.MyEcommerce.Entities.ProductAggregate
{
    public class Image : BaseEntity
    {
        public string Uri { get; set; }
        public int Position { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? ProductRatingId { get; set; }

    }
}

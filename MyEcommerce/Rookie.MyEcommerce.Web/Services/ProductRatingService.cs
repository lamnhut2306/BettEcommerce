using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Web.Services
{
    public class ProductRatingService : IProductRatingService
    {
        public Task<ProductRatingDto> AddProductRatingAsyn(ProductRatingDto productRatingDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductRatingAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductRatingDto>> GetProductRatingByProductAsync(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}

using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Web.Interfaces
{
    public interface IProductRatingService
    {
        Task<IEnumerable<ProductRatingDto>> GetProductRatingByProductAsync(Guid productId);
        Task<ProductRatingDto> AddProductRatingAsyn(ProductRatingDto productRatingDto);
        Task DeleteProductRatingAsync();
    }
}

using Rookie.MyEcommerce.Contracts;
using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface IProductRatingService
    {
        Task<IEnumerable<ProductRatingDto>> GetAllByProductAsync(Guid productId);

        Task<PagedResponseModel<ProductRatingDto>> PagedQueryAsync(string name, int page, int limit);

        Task<ProductRatingDto> GetByIdAsync(Guid id);

        Task<ProductRatingDto> AddAsync(ProductRatingDto productRatingDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductRatingDto productRatingDto);
    }
}

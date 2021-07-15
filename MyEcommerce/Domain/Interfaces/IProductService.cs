using Rookie.MyEcommerce.Contracts;
using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<PagedResponseModel<ProductDto>> PagedQueryAsync(string name, int page, int limit);

        Task<ProductDto> GetByIdAsync(Guid id);

        Task<ProductDto> AddAsync(ProductDto productDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductDto productDto);
    }
}

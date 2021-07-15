using Rookie.MyEcommerce.Contracts;
using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();

        Task<PagedResponseModel<CategoryDto>> PagedQueryAsync(string name, int page, int limit);

        Task<CategoryDto> GetByIdAsync(Guid id);

        Task<CategoryDto> AddAsync(CategoryDto categoryDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(CategoryDto categoryDto);
    }
}

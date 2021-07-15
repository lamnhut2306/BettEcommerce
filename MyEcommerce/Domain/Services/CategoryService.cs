using AutoMapper;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Rookie.MyEcommerce.Business.Extensions;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts;
using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _baseReposity;
        private readonly IMapper _mapper;

        public CategoryService(IBaseRepository<Category> baseRepository, IMapper mapper)
        {
            _baseReposity = baseRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            Ensure.Any.IsNotNull(categoryDto);
            var category = _mapper.Map<Category>(categoryDto);
            var result = await _baseReposity.AddAsync(category);
            return _mapper.Map<CategoryDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseReposity.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _baseReposity.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var category = await _baseReposity.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<PagedResponseModel<CategoryDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseReposity.Entities;
            query = query.Where(e => string.IsNullOrEmpty(name) || e.Name.Contains(name)).OrderBy(e => e.Name);

            var assets = await query.AsNoTracking().PaginateAsync(page, limit);
            return new PagedResponseModel<CategoryDto>()
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<CategoryDto>>(assets.Items)
            };
        }

        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _baseReposity.UpdateAsync(category);
        }
    }
}

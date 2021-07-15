using AutoMapper;
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
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _baseRepository;
        private readonly IMapper _mapper;
        public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var result = await _baseRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<PagedResponseModel<ProductDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;
            query = query.Where(e => string.IsNullOrEmpty(name) || e.Name.Contains(name)).OrderBy(e => e.Name);

            var assets = await query.AsNoTracking().PaginateAsync(page, limit);
            return new PagedResponseModel<ProductDto>()
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductDto>>(assets.Items)
            };
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _baseRepository.UpdateAsync(product);
        }
    }
}

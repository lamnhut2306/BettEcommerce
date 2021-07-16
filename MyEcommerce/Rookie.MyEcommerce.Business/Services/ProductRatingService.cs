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
    public class ProductRatingService : IProductRatingService
    {
        private readonly IBaseRepository<ProductRating> _baseRepository;
        private readonly IMapper _mapper;

        public ProductRatingService(IBaseRepository<ProductRating> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductRatingDto> AddAsync(ProductRatingDto productRatingDto)
        {
            var productRating = _mapper.Map<ProductRating>(productRatingDto);
            var result = await _baseRepository.AddAsync(productRating);
            return _mapper.Map<ProductRatingDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductRatingDto>> GetAllByProductAsync(Guid productId)
        {
            var productRatings = await _baseRepository.GetByAsync(x => x.ProductId == productId);
            return _mapper.Map<List<ProductRatingDto>>(productRatings);
        }

        public Task<ProductRatingDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<ProductRatingDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;
            query = query.Where(e => string.IsNullOrEmpty(name) || e.Comment.Contains(name)).OrderBy(e => e.CreatedDate);

            var assets = await query.AsNoTracking().PaginateAsync(page, limit);
            return new PagedResponseModel<ProductRatingDto>()
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductRatingDto>>(assets.Items)
            };
        }

        public async Task UpdateAsync(ProductRatingDto productRatingDto)
        {
            var productRating = _mapper.Map<ProductRating>(productRatingDto);
            await _baseRepository.UpdateAsync(productRating);
        }
    }
}

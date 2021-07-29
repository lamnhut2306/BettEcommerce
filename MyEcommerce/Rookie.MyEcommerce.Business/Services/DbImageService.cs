using AutoMapper;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Services
{
    public class DbImageService : IDbImageService
    {
        private readonly IBaseRepository<Image> _baseRepository;
        private readonly IMapper _mapper;

        public DbImageService(IBaseRepository<Image> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ImageDto> AddAsync(ImageDto imageDto)
        {
            var image = _mapper.Map<Image>(imageDto);
            var result = await _baseRepository.AddAsync(image);
            return _mapper.Map<ImageDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ImageDto>> GetAllByProductAsync(Guid productId)
        {
            var images = await _baseRepository.GetByAsync(i => i.ProductId == productId);
            return _mapper.Map<List<ImageDto>>(images);
        }

        public async Task<IEnumerable<ImageDto>> GetAllByProductRatingAsync(Guid productRatingId)
        {
            var images = await _baseRepository.GetByAsync(i => i.ProductRatingId == productRatingId);
            return _mapper.Map<List<ImageDto>>(images);
        }

        public async Task<ImageDto> GetByIdAsync(Guid id)
        {
            var image = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ImageDto>(image);
        }
    }
}

using AutoMapper;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Entities.CartAggregate;
using System;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Services
{
    public class CartService : ICartService
    {
        private readonly IBaseRepository<Cart> _baseRepository;
        private readonly IMapper _mapper;

        public CartService(IBaseRepository<Cart> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> AddAsync(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            var result = await _baseRepository.AddAsync(cart);
            return _mapper.Map<CartDto>(result);
        }

        public async Task<CartDto> GetByIdAsync(Guid id)
        {
            var cart = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<CartDto>(cart);
        }

        public async Task UpdateAsync(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            await _baseRepository.UpdateAsync(cart);
        }
    }
}

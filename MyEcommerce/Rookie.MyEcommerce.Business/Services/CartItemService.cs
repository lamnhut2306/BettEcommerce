using AutoMapper;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Entities.CartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IBaseRepository<CartItem> _baseRepository;
        private readonly IMapper _mapper;

        public CartItemService(IBaseRepository<CartItem> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<CartItemDto> AddAsync(CartItemDto cartItemDto)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemDto);
            var result = await _baseRepository.AddAsync(cartItem);
            return _mapper.Map<CartItemDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CartItemDto>> GetAllByCartAsync(Guid cartId)
        {
            var cartItems = await _baseRepository.GetByAsync(x => x.CartId == cartId);
            return _mapper.Map<List<CartItemDto>> (cartItems);
        }

        public async Task<CartItemDto> GetByIdAsync(Guid id)
        {
            var cartItem = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<CartItemDto>(cartItem);
        }

        public async Task UpdateAsync(CartItemDto cartItemDto)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemDto);
            await _baseRepository.UpdateAsync(cartItem);
        }
    }
}

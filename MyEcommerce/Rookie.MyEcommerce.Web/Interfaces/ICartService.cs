using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Web.Interfaces
{
    public interface ICartService
    {
        Task<CartDto> GetByUserIdAsync(Guid userId);
        Task<CartItemDto> AddCartItemAsync(CartItemDto cartItemDto);
        Task DelteCartItemAsync(Guid id);
        Task UpdateCartItemAsync(Guid cartId, CartItemDto cartItemDto);
    }
}

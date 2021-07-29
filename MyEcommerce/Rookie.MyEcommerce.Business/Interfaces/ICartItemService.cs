using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface ICartItemService
    {
        Task<CartItemDto> AddAsync(CartItemDto cartItemDto);
        Task<IEnumerable<CartItemDto>> GetAllByCartAsync(Guid cartId);
        Task<CartItemDto> GetByIdAsync(Guid id);
        Task UpdateAsync(CartItemDto cartItemDto);
        Task DeleteAsync(Guid id);
    }
}

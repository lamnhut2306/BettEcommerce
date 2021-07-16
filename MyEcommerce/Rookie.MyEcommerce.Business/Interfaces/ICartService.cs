using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface ICartService
    {
        Task<CartDto> GetByIdAsync(Guid id);

        Task<CartDto> AddAsync(CartDto cartDto);

        Task UpdateAsync(CartDto cartDto);
    }
}

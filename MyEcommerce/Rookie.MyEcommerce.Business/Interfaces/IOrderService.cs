using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();

        Task<OrderDto> GetByIdAsync(Guid id);

        Task<OrderDto> AddAsync(OrderDto orderDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(OrderDto orderDto);

        //Task UpdateStatusAsync(OrderHistoryDto orderHistoryDto);
    }
}

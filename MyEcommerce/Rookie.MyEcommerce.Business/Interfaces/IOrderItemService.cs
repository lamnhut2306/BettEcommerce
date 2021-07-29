using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItemDto> AddAsync(OrderItemDto orderItemDto);
        Task<IEnumerable<OrderItemDto>> GetAllByOrderAsync(Guid orderId);
        Task<OrderItemDto> GetByIdAsync(Guid id);
        Task UpdateAsync(OrderItemDto orderItemDto);
        Task DeleteAsync(Guid id);

    }
}

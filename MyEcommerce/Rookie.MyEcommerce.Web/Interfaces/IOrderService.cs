using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Web.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllByUserAsync(Guid userId);
        Task<OrderDto> AddOrderDto(OrderDto orderDto);
        Task<OrderDto> DeleteOrderAsync(Guid orderId);
    }
}

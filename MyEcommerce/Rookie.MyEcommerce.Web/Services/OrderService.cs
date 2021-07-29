using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Web.Services
{
    public class OrderService : IOrderService
    {
        public Task<OrderDto> AddOrderDto(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> DeleteOrderAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDto>> GetAllByUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}

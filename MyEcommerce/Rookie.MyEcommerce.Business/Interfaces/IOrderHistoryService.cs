using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface IOrderHistoryService
    {
        Task<IEnumerable<OrderHistoryDto>> GetAllByOrderAsync(Guid orderId);

        Task<OrderHistoryDto> GetByIdAsync(Guid id);

        Task<OrderHistoryDto> AddAsync(OrderHistoryDto orderHistoryDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(OrderHistoryDto orderHistoryDto);
    }
}

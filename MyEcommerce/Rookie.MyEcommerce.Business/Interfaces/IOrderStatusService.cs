using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface IOrderStatusService
    {
        Task<OrderStatusDto> GetByIdAsync(Guid id);

        Task<IEnumerable<OrderStatusDto>> GetAllAsync();

        Task UpdateAsync(OrderStatusDto entity);

    }
}

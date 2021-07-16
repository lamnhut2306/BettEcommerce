using AutoMapper;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IBaseRepository<OrderStatus> _baseRepository;
        private readonly IMapper _mapper;

        public OrderStatusService(IBaseRepository<OrderStatus> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderStatusDto>> GetAllAsync()
        {
            var orderStatuses = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<OrderStatusDto>>(orderStatuses);
        }

        public async Task<OrderStatusDto> GetByIdAsync(Guid id)
        {
            var orderStatus = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<OrderStatusDto>(orderStatus);
        }

        public async Task UpdateAsync(OrderStatusDto entity)
        {
            var orderStatus = _mapper.Map<OrderStatus>(entity);
            await _baseRepository.UpdateAsync(orderStatus);
        }
    }
}

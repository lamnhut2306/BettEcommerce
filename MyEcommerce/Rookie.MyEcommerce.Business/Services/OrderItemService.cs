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
    public class OrderItemService : IOrderItemService
    {
        private readonly IBaseRepository<OrderItem> _baseReposity;
        private readonly IMapper _mapper;

        public OrderItemService(IBaseRepository<OrderItem> baseRepository, IMapper mapper)
        {
            _baseReposity = baseRepository;
            _mapper = mapper;
        }
        public async Task<OrderItemDto> AddAsync(OrderItemDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            var result = await _baseReposity.AddAsync(orderItem);
            return _mapper.Map<OrderItemDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseReposity.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllByOrderAsync(Guid orderId)
        {
            var orderItems = await _baseReposity.GetByAsync(x => x.OrderId == orderId);
            return _mapper.Map<List<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> GetByIdAsync(Guid id)
        {
            var orderItem = await _baseReposity.GetByIdAsync(id);
            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task UpdateAsync(OrderItemDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _baseReposity.UpdateAsync(orderItem);
        }
    }
}

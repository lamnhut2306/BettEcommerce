using AutoMapper;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _baseRepository;
        private readonly IMapper _mapper;

        public OrderService(IBaseRepository<Order> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<OrderDto> AddAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var result = await _baseRepository.AddAsync(order);
            return _mapper.Map<OrderDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var order = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task UpdateAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _baseRepository.UpdateAsync(order);
        }
    }
}

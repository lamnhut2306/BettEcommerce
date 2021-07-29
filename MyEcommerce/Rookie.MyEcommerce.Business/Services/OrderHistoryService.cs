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
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IBaseRepository<OrderHistory> _baseReposity;
        private readonly IMapper _mapper;

        public OrderHistoryService(IBaseRepository<OrderHistory> baseRepository, IMapper mapper)
        {
            _baseReposity = baseRepository;
            _mapper = mapper;
        }

        public async Task<OrderHistoryDto> AddAsync(OrderHistoryDto orderHistoryDto)
        {
            var orderHistory = _mapper.Map<OrderHistory>(orderHistoryDto);
            var result = await _baseReposity.AddAsync(orderHistory);
            return _mapper.Map<OrderHistoryDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseReposity.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderHistoryDto>> GetAllByOrderAsync(Guid orderId)
        {
            var orderHistories = await _baseReposity.GetByAsync(oh => oh.OrderId == orderId);
            return _mapper.Map<List<OrderHistoryDto>>(orderHistories);
        }

        public async Task<OrderHistoryDto> GetByIdAsync(Guid id)
        {
            var orderHistory = await _baseReposity.GetByIdAsync(id);
            return _mapper.Map<OrderHistoryDto>(orderHistory);
        }

        public async Task UpdateAsync(OrderHistoryDto orderHistoryDto)
        {
            var orderHistory = _mapper.Map<OrderHistory>(orderHistoryDto);
            await _baseReposity.UpdateAsync(orderHistory);
        }
    }
}

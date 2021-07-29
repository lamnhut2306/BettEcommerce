using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts.Constants;
using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryService _orderHistoryService;

        public OrderHistoryController(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }

        [HttpGet("order/{orderId}")]
        public async Task<IEnumerable<OrderHistoryDto>> GetAllByOrderAsync(Guid orderId)
        {
            return await _orderHistoryService.GetAllByOrderAsync(orderId);
        }

        [HttpGet("{id}")]
        public async Task<OrderHistoryDto> GetByIdAsync(Guid id)
        {
            return await _orderHistoryService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<OrderHistoryDto>> AddAsync(OrderHistoryDto orderHistoryDto)
        {
            var result = await _orderHistoryService.AddAsync(orderHistoryDto);
            return Created(Endpoints.OrderHistory, result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Guid id, OrderHistoryDto orderHistoryDto)
        {
            if (id != orderHistoryDto.Id) return BadRequest();

            await _orderHistoryService.UpdateAsync(orderHistoryDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _orderHistoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}

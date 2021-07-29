using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts.Constants;
using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rookie.MyEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("order/{orderId}")]
        public async Task<IEnumerable<OrderItemDto>> GetAllByOrderAsync(Guid orderId)
        {
            return await _orderItemService.GetAllByOrderAsync(orderId);
        }

        [HttpGet("{id}")]
        public async Task<OrderItemDto> GetByIdAsync(Guid id)
        {
            return await _orderItemService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDto>> AddAsync(OrderItemDto OrderItemDto)
        {
            var result = await _orderItemService.AddAsync(OrderItemDto);
            return Created(Endpoints.OrderItem, result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Guid id, OrderItemDto OrderItemDto)
        {
            if (id != OrderItemDto.Id) return BadRequest();

            await _orderItemService.UpdateAsync(OrderItemDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _orderItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}

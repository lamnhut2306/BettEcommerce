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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderHistoryService _orderHistoryService;

        public OrderController(IOrderService orderService, IOrderHistoryService orderHistoryService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderHistoryService = orderHistoryService;
            _orderItemService = orderItemService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
            => await _orderService.GetAllAsync();

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<OrderDto>> GetAsync(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            order.OrderItems = await _orderItemService.GetAllByOrderAsync(id);
            order.OrderHistories = await _orderHistoryService.GetAllByOrderAsync(id);

            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        [Authorize(Roles = AppRole.Customer)]
        public async Task<ActionResult<OrderDto>> AddAsync(OrderDto orderDto)
        {
            var result = await _orderService.AddAsync(orderDto);
            return Created(Endpoints.Order, result);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] OrderDto orderDto)
        {
            if (id != orderDto.Id) return BadRequest();
            await _orderService.UpdateAsync(orderDto);
            return NoContent();
        }

        [HttpPut("orderhistory/{id}")]
        public async Task<ActionResult<OrderHistoryDto>> UpdateHistoryAsync(Guid id, OrderHistoryDto orderHistoryDto)
        {
            if (id != orderHistoryDto.OrderId) return BadRequest();
            var result = await _orderHistoryService.AddAsync(orderHistoryDto);

            return Ok(result);
        }
    }
}

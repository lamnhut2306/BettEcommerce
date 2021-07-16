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

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
            => await _orderService.GetAllAsync();


        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetAsync(Guid id)
            => await _orderService.GetByIdAsync(id);

        // POST api/<OrderController>
        [HttpPost]
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
    }
}

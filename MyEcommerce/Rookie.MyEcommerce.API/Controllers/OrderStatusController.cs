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
    [Authorize(Roles = AppRole.Admin)]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpGet("order/{orderId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<OrderStatusDto>> GetAllAsync()
        {
            return await _orderStatusService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<OrderStatusDto> GetByIdAsync(Guid id)
        {
            return await _orderStatusService.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Guid id, OrderStatusDto OrderStatusDto)
        {
            if (id != OrderStatusDto.Id) return BadRequest();

            await _orderStatusService.UpdateAsync(OrderStatusDto);
            return NoContent();
        }
    }
}

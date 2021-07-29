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
    [Authorize(Roles = AppRole.Customer)]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        // GET: api/<CartItemController>
        [HttpGet("cart/{cartId}")]
        public async Task<IEnumerable<CartItemDto>> GetAllByCartAsync(Guid cartId)
        {
            return await _cartItemService.GetAllByCartAsync(cartId);
        }

        // GET api/<CartItemController>/5
        [HttpGet("{id}")]
        public async Task<CartItemDto> GetAsync(Guid id)
        {
            return await _cartItemService.GetByIdAsync(id);
        }

        // POST api/<CartItemController>
        [HttpPost]
        public async Task<ActionResult<CartItemDto>> AddAsync([FromBody] CartItemDto cartItemDto)
        {
            var result = await _cartItemService.AddAsync(cartItemDto);
            return Created(Endpoints.CartItem, result);
        }

        // PUT api/<CartItemController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] CartItemDto cartItemDto)
        {
            if (id != cartItemDto.Id) return BadRequest();
            await _cartItemService.UpdateAsync(cartItemDto);

            return NoContent();
        }

        // DELETE api/<CartItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _cartItemService.DeleteAsync(id);

            return NoContent();
        }
    }
}

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
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public async Task<CartDto> GetAsync(Guid id)
            => await _cartService.GetByIdAsync(id);

        // POST api/<CartController>
        [HttpPost]
        public async Task<ActionResult<CartDto>> AddAsync(CartDto cartDto)
        {
            var result = await _cartService.AddAsync(cartDto);
            return Created(Endpoints.Cart, result);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, CartDto cartDto)
        {
            if (id != cartDto.Id) return BadRequest();
            await _cartService.UpdateAsync(cartDto);
            return NoContent();
        }
    }
}

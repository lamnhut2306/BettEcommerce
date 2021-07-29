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
    [Authorize(Roles = AppRole.Customer)]
    public class ProductRatingController : ControllerBase
    {
        private readonly IProductRatingService _productRatingService;

        public ProductRatingController(IProductRatingService productRatingService)
        {
            _productRatingService = productRatingService;
        }

        [HttpGet("{productId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductRatingDto>> GetAllByProductAsync(Guid productId)
        {
            return await _productRatingService.GetAllByProductAsync(productId);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ProductRatingDto> GetByIdAsync(Guid id)
        {
            return await _productRatingService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<ProductRatingDto>> AddAsync(ProductRatingDto productRatingDto)
        {
            var result = await _productRatingService.AddAsync(productRatingDto);
            return Created(Endpoints.ProductRating, result);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _productRatingService.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductRatingDto>> 
            UpdateAsync(Guid id, ProductRatingDto productRatingDto)
        {
            if (id != productRatingDto.Id) return BadRequest();
            
            await _productRatingService.UpdateAsync(productRatingDto);
            return NoContent();
        }
    }
}

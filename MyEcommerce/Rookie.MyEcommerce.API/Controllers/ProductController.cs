using EnsureThat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
            => await _productService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ProductDto> GetByIdAsync(Guid id)
            => await _productService.GetByIdAsync(id);

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
            => await _productService.DeleteAsync(id);

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddAsync(ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto);
            var result = await _productService.AddAsync(productDto);
            return Created(Endpoints.Product, result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto.Description);
            Ensure.Any.IsNotNull(productDto.Name);
            await _productService.UpdateAsync(productDto);
            return NoContent();
        }

        [HttpGet("/find")]
        public async Task<PagedResponseModel<ProductDto>>
            FindAsync(string name, int page = BaseQueryCriteria.Page, int limit = BaseQueryCriteria.Limit)
            => await _productService.PagedQueryAsync(name, page, limit);

    }
}

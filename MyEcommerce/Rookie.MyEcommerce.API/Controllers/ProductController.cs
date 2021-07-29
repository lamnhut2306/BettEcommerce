using EnsureThat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rookie.MyEcommerce.API.Interfaces;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts;
using Rookie.MyEcommerce.Contracts.Constants;
using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = AppRole.Admin)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IFolderImageService _folderImageService;

        public ProductController(IProductService productService, IFolderImageService folderImageService)
        {
            _productService = productService;
            _folderImageService = folderImageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
            => await _productService.GetAllAsync();

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ProductDto> GetByIdAsync(Guid id)
            => await _productService.GetByIdAsync(id);

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _productService.DeleteAsync(id);
            await _folderImageService.RemoveAllAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddAsync(ProductDto productDto)
        {
            var result = await _productService.AddAsync(productDto);
            return Created(Endpoints.Product, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto.Description);
            Ensure.Any.IsNotNull(productDto.Name);
            await _productService.UpdateAsync(productDto);
            return NoContent();
        }

        [HttpGet("find")]
        [AllowAnonymous]
        public async Task<PagedResponseModel<ProductDto>>
            FindAsync(string name, int page = BaseQueryCriteria.Page, int limit = BaseQueryCriteria.Limit)
            => await _productService.PagedQueryAsync(name, page, limit);
    }
}

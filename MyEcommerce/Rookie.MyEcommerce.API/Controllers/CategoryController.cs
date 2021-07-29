using EnsureThat;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
            => await _categoryService.GetAllAsync();

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<CategoryDto> GetByIdAsync(Guid id)
            => await _categoryService.GetByIdAsync(id);

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddAsync([FromBody]CategoryDto categoryDto)
        {
            Ensure.Any.IsNotNull(categoryDto.Name);
            Ensure.Any.IsNotNull(categoryDto.Description);

            var result = await _categoryService.AddAsync(categoryDto);
            return Created(Endpoints.Category, result);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            Ensure.Any.IsNotNull(categoryDto.Name);
            Ensure.Any.IsNotNull(categoryDto.Description);

            await _categoryService.UpdateAsync(categoryDto);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}

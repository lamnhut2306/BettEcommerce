using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.MyEcommerce.API.Interfaces;
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
    public class ProductImageController : ControllerBase
    {
        private readonly IFolderImageService _folderImageService;
        private readonly IDbImageService _dbImageService;

        public ProductImageController(IFolderImageService folderImageService, IDbImageService dbImageService)
        {
            _folderImageService = folderImageService;
            _dbImageService = dbImageService;
        }
        // GET: api/<ImageController>
        [HttpGet("product/{productId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ImageDto>> GetAllByProductAsync(Guid productId)
        {
            return await _dbImageService.GetAllByProductAsync(productId);
        }

        [HttpDelete("product/{productId}")]
        public async Task<ActionResult> DeleteAllByProductAsync(Guid productId)
        {
        /*  var images = await _dbImageService.GetAllByProductAsync(productId);

            foreach (var image in images)
            {
                await _dbImageService.DeleteAsync(image.Id);
            }
            */
            await _folderImageService.RemoveAllAsync(productId);

            return NoContent();
        }

        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ImageDto> GetByIdAsync(Guid id)
        {
            return await _dbImageService.GetByIdAsync(id);
        }

        // POST api/<ImageController>
        [HttpPost("{productId}")]
        public async Task<ActionResult> AddAsync(Guid productId, [FromForm]List<IFormFile> formFiles)
        {
            var image = new ImageDto() 
            { 
                ProductId = productId
            };

            List<ImageDto> images = new();

            foreach (var formFile in formFiles)
            {
                image.Position = images.Count;
                image = await _folderImageService.SaveAsync(formFile, image);
                var result = await _dbImageService.AddAsync(image);
                images.Add(result);
            }

            return Created(Endpoints.Image, images);
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            var image = await _dbImageService.GetByIdAsync(id);
            await _folderImageService.RemoveAsync(image);
            await _dbImageService.DeleteAsync(id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.API.Interfaces
{
    public interface IFolderImageService
    {
        public Task<ImageDto> SaveAsync(IFormFile formFile, ImageDto imageDto);
        public Task RemoveAsync(ImageDto imageDto);
        public Task RemoveAllAsync(Guid id);
    }
}

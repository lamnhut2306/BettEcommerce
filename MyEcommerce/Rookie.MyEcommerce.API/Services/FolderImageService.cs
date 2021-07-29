using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Rookie.MyEcommerce.API.Interfaces;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.API.Services
{
    public class FolderImageService : IFolderImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FolderImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task RemoveAllAsync(Guid id)
        {
            var folderName = id.ToString();

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Image");
            path = Path.Combine(path, folderName);

            if (Directory.Exists(path))
            {
                void deleteDirectory() => Directory.Delete(path, true);
                await Task.Run(deleteDirectory);
            }
        }

        public async Task RemoveAsync(ImageDto imageDto)
        {
            void deleteFile() => File.Delete(imageDto.Uri);
            await Task.Run(deleteFile);
        }

        public async Task<ImageDto> SaveAsync(IFormFile formFile, ImageDto imageDto)
        {
            var id = Guid.NewGuid();

            var fileName = id.ToString() + Path.GetExtension(formFile.FileName);
            var folderName = (imageDto.ProductId != Guid.Empty ? imageDto.ProductId : imageDto.ProductRatingId).ToString();
            

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Image");
            path = Path.Combine(path, folderName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fullPath = Path.Combine(path, fileName);

            using (Stream stream = new FileStream(fullPath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            imageDto.Uri = $"~/Image/${folderName}/${fileName}";
            imageDto.Id = id;

            return imageDto;
        }
    }
}

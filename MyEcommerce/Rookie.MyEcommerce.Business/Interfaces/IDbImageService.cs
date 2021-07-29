using Rookie.MyEcommerce.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Business.Interfaces
{
    public interface IDbImageService
    {
        Task<IEnumerable<ImageDto>> GetAllByProductAsync(Guid productId);
        Task<IEnumerable<ImageDto>> GetAllByProductRatingAsync(Guid productRatingId);

        Task<ImageDto> GetByIdAsync(Guid id);
        Task<ImageDto> AddAsync(ImageDto imageDto);
        Task DeleteAsync(Guid id);
    }
}

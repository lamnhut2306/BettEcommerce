using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Web.Services
{
    public class ProductService : IProductService
    {
        public Task<IEnumerable<ProductDto>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}

using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",)
        }
        public Task<CartItemDto> AddCartItemAsync(CartItemDto cartItemDto)
        {
            throw new NotImplementedException();
        }

        public Task DelteCartItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartItemAsync(Guid cartId, CartItemDto cartItemDto)
        {
            throw new NotImplementedException();
        }
    }
}

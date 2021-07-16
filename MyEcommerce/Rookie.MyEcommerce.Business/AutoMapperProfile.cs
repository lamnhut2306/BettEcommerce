
using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Entities.CartAggregate;
using Rookie.MyEcommerce.Entities.OrderAggregate;
using Rookie.MyEcommerce.Entities.ProductAggregate;
using System.Linq;

namespace Rookie.MyEcommerce.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<CategoryDto, Category>()
                .ForMember(c => c.Id, cDto => cDto.MapFrom(e => e.Id))
                .ForMember(c => c.Products, cDto => cDto.Ignore())
                .ForMember(c => c.CreatedDate, cDto => cDto.Ignore());
            CreateMap<CartDto, Cart>();
            CreateMap<CartItemDto, CartItem>()
                .ForMember(ci => ci.Cart, ciDto => ciDto.Ignore());
            CreateMap<OrderDto, Order>();
            CreateMap<OrderHistoryDto, OrderHistory>()
                .ForMember(oh => oh.Order, ohDto => ohDto.Ignore())
                .ForMember(oh => oh.OrderStatus, ohDto => ohDto.Ignore());
            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(oi => oi.Product, oiDto => oiDto.Ignore())
                .ForMember(oi => oi.Order, oiDto => oiDto.Ignore());
            CreateMap<OrderStatusDto, OrderStatus>()
                .ForMember(os => os.OrderHistories, osDto => osDto.Ignore());
            CreateMap<AddressDto, Address>();
            CreateMap<ImageDto, Image>();
            CreateMap<ProductDto, Product>()
                .ForMember(p => p.OrderItems, pDto => pDto.Ignore())
                .ForMember(p => p.ProductRatings, pDto => pDto.Ignore())
                .ForMember(p => p.Category, pDto => pDto.Ignore());
            CreateMap<ProductRatingDto, ProductRating>()
                .ForMember(pr => pr.Product, prDto => prDto.Ignore());
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartItem, CartItemDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderHistory, OrderHistoryDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderStatus, OrderStatusDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductRating, ProductRatingDto>();
        }
    }
}

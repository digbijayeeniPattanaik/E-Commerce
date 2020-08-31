using API.Dtos;
using AutoMapper;
using Core.Entites;
using Core.Entites.OrderAggregate;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(a => a.ProductBrand, o => o.MapFrom(a => a.ProductBrand.Name))
                .ForMember(a => a.ProductType, o => o.MapFrom(a => a.ProductType.Name))
                .ForMember(a => a.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<Core.Entites.Identity.Address, AddressDto>().ReverseMap();
            ////CreateMap<AddressDto, Address>();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Core.Entites.OrderAggregate.Address>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(a => a.DeliveryMethod, o => o.MapFrom(a => a.DeliveryMethod.ShortName))
                .ForMember(a => a.ShippingPrice, o => o.MapFrom(a => a.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderITemDto>()
                .ForMember(a => a.ProductId, o => o.MapFrom(a => a.ItemOrdered.ProductItemId))
                .ForMember(a => a.ProductName, o => o.MapFrom(a => a.ItemOrdered.ProductName))
                .ForMember(a => a.PictureUrl, o => o.MapFrom(a => a.ItemOrdered.PictureUrl))
                .ForMember(a => a.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}

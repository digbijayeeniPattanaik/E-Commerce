using API.Dtos;
using AutoMapper;
using Core.Entites;

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
        }
    }
}

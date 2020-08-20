using API.Dtos;
using AutoMapper;
using Core.Entites;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.PictureUrl))
                return _configuration["ApiUrl"] + source.PictureUrl;
            else return null;
        }
    }
}

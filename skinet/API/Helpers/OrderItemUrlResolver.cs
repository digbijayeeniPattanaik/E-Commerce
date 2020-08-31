using API.Dtos;
using AutoMapper;
using Core.Entites.OrderAggregate;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderITemDto, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderITemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.ItemOrdered.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.ItemOrdered.PictureUrl;
            }

            return null;
        }
    }
}

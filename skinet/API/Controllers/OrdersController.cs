using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entites.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User?.RetrieveEmailFromPrincipal();

            var address = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);

            var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

            if (order == null) return BadRequest(new ApiResponse((int)HttpStatusCode.BadRequest, "Problem creating order"));

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Order>>> GetOrdersForUser()
        {
            var email = HttpContext.User?.RetrieveEmailFromPrincipal();
            var orders = await _orderService.GetOrderForUserAsync(email);

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderForUser(int id)
        {
            var email = HttpContext.User?.RetrieveEmailFromPrincipal();
            var order = await _orderService.GetOrderByIdAsync(id, email);

            if (order == null) return BadRequest(new ApiResponse((int)HttpStatusCode.NotFound, "Order Not Found"));

            return Ok(order);
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            return Ok(await _orderService.GetDeliveryMethodAsync());
        }
    }
}
using Core.Entites;
using Core.Entites.OrderAggregate;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<DeliveryMethod> _dmRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IBasketRepository _basketRepository;

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<DeliveryMethod> dmRepo, IGenericRepository<Product> productRepo, IBasketRepository basketRepository)
        {
            _orderRepo = orderRepo;
            _dmRepo = dmRepo;
            _productRepo = productRepo;
            _basketRepository = basketRepository;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //get basket from the repo
            var basket = await _basketRepository.GetBasketAsync(basketId);
            // get items for the product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            //get delivery method
            var deliveryMethod = await _dmRepo.GetByIdAsync(deliveryMethodId);
            // calc subtotal
            var subTotal = items.Sum(item => item.Price * item.Quantity);
            //create order
            var order = new Order(buyerEmail, shippingAddress, deliveryMethod, items, subTotal);
            //save to db
            //return order
            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}

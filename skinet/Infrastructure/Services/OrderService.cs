using Core;
using Core.Entites;
using Core.Entites.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;// it is using a databse thats why explicitly written and not using generic database.

        public OrderService(IUnitOfWork unitOfWork, IBasketRepository basketRepository)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //get basket from the repo
            var basket = await _basketRepository.GetBasketAsync(basketId);
            // get items for the product repo
            if (basket != null)
            {
                var items = new List<OrderItem>();
                foreach (var item in basket.Items)
                {
                    var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                    var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                    var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                    items.Add(orderItem);
                }

                //get delivery method
                var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
                // calc subtotal
                var subTotal = items.Sum(item => item.Price * item.Quantity);
                //create order
                var order = new Order(buyerEmail, shippingAddress, deliveryMethod, items, subTotal);
                _unitOfWork.Repository<Order>().Add(order);
                //save to db
                var results = await _unitOfWork.Complete();

                if (results <= 0) return null;

                await _basketRepository.DeleteBasketAsync(basketId);

                //return order
                return order;
            }

            return null;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync()
        {
           return await _unitOfWork.Repository<DeliveryMethod>().GetListAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);
            return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrderForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);

            return await _unitOfWork.Repository<Order>().ListAsync(spec);
        }
    }
}

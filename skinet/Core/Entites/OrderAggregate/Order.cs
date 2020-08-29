using System;
using System.Collections.Generic;

namespace Core.Entites.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order()
        {

        }
        public Order(string buyerEmail, Address shipToAdress, DeliveryMethod deliveryMethod, IReadOnlyList<OrderItem> orderItems, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            ShipToAdress = shipToAdress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            SubTotal = subTotal;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAdress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }
        public decimal GetTotal() => SubTotal + DeliveryMethod.Price;
    }
}

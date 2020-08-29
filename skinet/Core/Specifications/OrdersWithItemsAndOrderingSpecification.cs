using Core.Entites.OrderAggregate;

namespace Core.Specifications
{
    public class OrdersWithItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
        {
            AddInclude(a => a.OrderItems);
            AddInclude(a => a.DeliveryMethod);
            AddOrderByDescending(a => a.OrderDate);
        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email) : base(o => o.Id == id && o.BuyerEmail == email)
        {
            AddInclude(a => a.OrderItems);
            AddInclude(a => a.DeliveryMethod);
        }
    }
}

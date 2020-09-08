using Core.Entites;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPaymentsService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
    }
}

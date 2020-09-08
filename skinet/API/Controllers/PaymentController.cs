using API.Dtos;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentsService _paymentService;

        public PaymentController(IPaymentsService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
        {
            return await _paymentService.CreateOrUpdatePaymentIntent(basketId);
        }
    }
}
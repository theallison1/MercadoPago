using MercadoPago.CheckoutAPI.Helpers;
using MercadoPago.CheckoutAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        public readonly IPaymentsService _paymentsService;

        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }

        [HttpGet("{paymentId:int}")]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            var response = await _paymentsService.GetPaymentById(paymentId);

            return response.ReturnStatusCode(this);
        }

        [HttpGet("Search={externalReference}")]
        public async Task<IActionResult> GetPaymentByExternalReference(string externalReference)
        {
            var response = await _paymentsService.GetPaymentByExternalReference(externalReference);

            return response.ReturnStatusCode(this);
        }
    }
}

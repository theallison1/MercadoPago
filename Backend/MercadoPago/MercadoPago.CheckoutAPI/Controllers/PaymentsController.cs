using MercadoPago.CheckoutAPI.Helpers;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Request;
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

        [HttpGet("Search")]
        public async Task<IActionResult> SearchPayments([FromQuery] SearchPaymentsRequestFilters filters)
        {
            var response = await _paymentsService.SearchPayments(filters);

            return response.ReturnStatusCode(this);
        }

        [HttpGet("{paymentId:int}")]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            var response = await _paymentsService.GetPaymentById(paymentId);

            return response.ReturnStatusCode(this);
        }

    }
}

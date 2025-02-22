using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Payments.Request;
using MercadoPago.CheckoutAPI.Helpers;
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

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest bodyRequest)
        {
            var response = await _paymentsService.CreatePayment(bodyRequest);

            return response.ReturnStatusCode(this);
        }

    }
}

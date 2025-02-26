using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Payments.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers.MercadoPago
{
    [Route("api/MercadoPago/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        public readonly IPaymentsApplication _paymentsApplication;

        public PaymentsController(IPaymentsApplication paymentsApplication)
        {
            _paymentsApplication = paymentsApplication;
        }

        [Authorize(Roles = "administrator")]
        [HttpGet("Search")]
        public async Task<IActionResult> SearchPayments([FromQuery] PaymentsRequestFilters filters)
        {
            var response = await _paymentsApplication.SearchPayments(filters);

            return StatusCode(response.StatusCode, response);
        }

        [Authorize(Roles = "administrator")]
        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            var response = await _paymentsApplication.GetPaymentById(paymentId);

            return StatusCode(response.StatusCode, response);
        }


        [Authorize(Roles = "administrator,customer")]
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest bodyRequest)
        {
            var response = await _paymentsApplication.CreatePayment(bodyRequest);

            return StatusCode(response.StatusCode, response);
        }

        [Authorize(Roles = "administrator")]
        [HttpPut("{paymentId}")]
        public async Task<IActionResult> UpdatePayment(int paymentId, [FromBody] PaymentRequest bodyRequest)
        {
            var response = await _paymentsApplication.UpdatePayment(paymentId, bodyRequest);

            return StatusCode(response.StatusCode, response);
        }

    }
}

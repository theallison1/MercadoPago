using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Payments.Request;
using MercadoPago.CheckoutAPI.Helpers;
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
        public async Task<IActionResult> SearchPayments([FromQuery] SearchPaymentsRequestFilters filters)
        {
            var response = await _paymentsApplication.SearchPayments<object>(filters);

            return response.ReturnStatusCode(this);
        }

        [Authorize(Roles = "administrator")]
        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            var response = await _paymentsApplication.GetPaymentById<object>(paymentId);

            return response.ReturnStatusCode(this);
        }


        [Authorize(Roles = "administrator,customer")]
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest bodyRequest)
        {
            var response = await _paymentsApplication.CreatePayment<object>(bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [Authorize(Roles = "administrator")]
        [HttpPut("{paymentId}")]
        public async Task<IActionResult> UpdatePayment(int paymentId, [FromBody] PaymentRequest bodyRequest)
        {
            var response = await _paymentsApplication.UpdatePayment<object>(paymentId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

    }
}

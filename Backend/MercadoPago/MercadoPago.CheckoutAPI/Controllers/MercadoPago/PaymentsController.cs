using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Payments.Request;
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
            var response = await _paymentsApplication.SearchPayments(filters);

            return response.ReturnStatusCode(this);
        }

        [Authorize(Roles = "administrator")]
        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            var response = await _paymentsApplication.GetPaymentById(paymentId);

            return response.ReturnStatusCode(this);
        }


        [Authorize(Roles = "administrator,customer")]
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest bodyRequest)
        {
            var response = await _paymentsApplication.CreatePayment(bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [Authorize(Roles = "administrator")]
        [HttpPut("{paymentId}")]
        public async Task<IActionResult> UpdatePayment(int paymentId, [FromBody] UpdatePaymentRequest bodyRequest)
        {
            var response = await _paymentsApplication.UpdatePayment(paymentId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

    }
}

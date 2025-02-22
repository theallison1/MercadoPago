using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.PaymentMethods.Request;
using MercadoPago.CheckoutAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodsApplication _paymentMethodsApplication;

        public PaymentMethodsController(IPaymentMethodsApplication paymentMethodsApplication)
        {
            _paymentMethodsApplication = paymentMethodsApplication;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchPaymentMethods([FromQuery] SearchPaymentMethodsRequestFilters filters)
        {
            var response = await _paymentMethodsApplication.SearchPaymentMethods(filters);

            return response.ReturnStatusCode(this);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var response = await _paymentMethodsApplication.GetPaymentMethods();

            return response.ReturnStatusCode(this);
        }
    }
}

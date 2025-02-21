using MercadoPago.CheckoutAPI.HttpUtilities;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.PaymentMethods.Request;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodsService _paymentMethodsService;

        public PaymentMethodsController(IPaymentMethodsService paymentMethodsService)
        {
            _paymentMethodsService = paymentMethodsService;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchPaymentMethods([FromQuery] SearchPaymentMethodsRequestFilters filters)
        {
            var response = await _paymentMethodsService.SearchPaymentMethods(filters);

            return response.ReturnStatusCode(this);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var response = await _paymentMethodsService.GetPaymentMethods();

            return response.ReturnStatusCode(this);
        }
    }
}

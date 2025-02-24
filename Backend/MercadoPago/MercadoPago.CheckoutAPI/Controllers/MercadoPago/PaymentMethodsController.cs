﻿using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.PaymentMethods.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers.MercadoPago
{
    [Authorize]
    [Route("api/MercadoPago/[controller]")]
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
            var response = await _paymentMethodsApplication.SearchPaymentMethods<object>(filters);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var response = await _paymentMethodsApplication.GetPaymentMethods<object>();

            return StatusCode(response.StatusCode, response);
        }
    }
}

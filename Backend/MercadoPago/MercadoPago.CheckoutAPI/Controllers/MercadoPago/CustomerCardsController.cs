using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.CustomerCards.Request;
using MercadoPago.CheckoutAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers.MercadoPago
{
    [Authorize(Roles = "administrator")]
    [Route("api/MercadoPago/[controller]")]
    [ApiController]
    public class CustomerCardsController : ControllerBase
    {
        private readonly ICustomerCardsApplication _customerCardsApplication;

        public CustomerCardsController(ICustomerCardsApplication customerCardsApplication)
        {
            _customerCardsApplication = customerCardsApplication;
        }

        [HttpGet("{customerId}/cards")]
        public async Task<IActionResult> GetCustomerCards(string customerId)
        {
            var response = await _customerCardsApplication.GetCustomerCards<object>(customerId);

            return response.ReturnStatusCode(this);
        }

        [HttpGet("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> GetCustomerCardById(string customerId, string cardId)
        {
            var response = await _customerCardsApplication.GetCustomerCardById<object>(customerId, cardId);

            return response.ReturnStatusCode(this);
        }

        [HttpPost("{customerId}/cards")]
        public async Task<IActionResult> CreateCustomerCard(string customerId, [FromBody] CustomerCardRequest bodyRequest)
        {
            var response = await _customerCardsApplication.CreateCustomerCard<object>(customerId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [HttpPut("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> UpdateCustomerCard(string customerId, string cardId, [FromBody] CustomerCardRequest bodyRequest)
        {
            var response = await _customerCardsApplication.UpdateCustomerCard<object>(customerId, cardId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [HttpDelete("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> DeleteCustomerCard(string customerId, string cardId)
        {
            var response = await _customerCardsApplication.DeleteCustomerCard<object>(customerId, cardId);

            return response.ReturnStatusCode(this);
        }
    }
}

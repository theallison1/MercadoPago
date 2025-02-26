using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.CustomerCards.Request;
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
            var response = await _customerCardsApplication.GetCustomerCards(customerId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> GetCustomerCardById(string customerId, string cardId)
        {
            var response = await _customerCardsApplication.GetCustomerCardById(customerId, cardId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{customerId}/cards")]
        public async Task<IActionResult> CreateCustomerCard(string customerId, [FromBody] CustomerCardRequest bodyRequest)
        {
            var response = await _customerCardsApplication.CreateCustomerCard(customerId, bodyRequest);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> UpdateCustomerCard(string customerId, string cardId, [FromBody] CustomerCardRequest bodyRequest)
        {
            var response = await _customerCardsApplication.UpdateCustomerCard(customerId, cardId, bodyRequest);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> DeleteCustomerCard(string customerId, string cardId)
        {
            var response = await _customerCardsApplication.DeleteCustomerCard(customerId, cardId);

            return StatusCode(response.StatusCode, response);
        }
    }
}

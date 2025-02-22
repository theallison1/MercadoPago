using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.CustomerCards.Request;
using MercadoPago.CheckoutAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCardsController : ControllerBase
    {
        private readonly ICustomerCardsService _customerCardsService;

        public CustomerCardsController(ICustomerCardsService customerCardsService)
        {
            _customerCardsService = customerCardsService;
        }

        [HttpGet("{customerId}/cards")]
        public async Task<IActionResult> GetCustomerCards(string customerId)
        {
            var response = await _customerCardsService.GetCustomerCards(customerId);

            return response.ReturnStatusCode(this);
        }

        [HttpGet("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> GetCustomerCardById(string customerId, string cardId)
        {
            var response = await _customerCardsService.GetCustomerCardById(customerId, cardId);

            return response.ReturnStatusCode(this);
        }

        [HttpPost("{customerId}/cards")]
        public async Task<IActionResult> CreateCustomerCard(string customerId, [FromBody] CreateCustomerCardRequest bodyRequest)
        {
            var response = await _customerCardsService.CreateCustomerCard(customerId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [HttpPut("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> UpdateCustomerCard(string customerId, string cardId, [FromBody] UpdateCustomerCardRequest bodyRequest)
        {
            var response = await _customerCardsService.UpdateCustomerCard(customerId, cardId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [HttpDelete("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> DeleteCustomerCard(string customerId, string cardId)
        {
            var response = await _customerCardsService.DeleteCustomerCard(customerId, cardId);

            return response.ReturnStatusCode(this);
        }
    }
}

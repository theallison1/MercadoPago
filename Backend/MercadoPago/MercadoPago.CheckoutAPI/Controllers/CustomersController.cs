using MercadoPago.CheckoutAPI.HttpUtilities;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Customers.Request;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchCustomers([FromQuery] SearchCustomersRequestFilters filters) 
        {
            var response = await _customersService.SearchCustomers(filters);

            return response.ReturnStatusCode(this);
        }


        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(string customerId) 
        {
            var response = await _customersService.GetCustomerById(customerId);

            return response.ReturnStatusCode(this);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest bodyRequest)
        {
            var response = await _customersService.CreateCustomer(bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(string customerId, [FromBody] UpdateCustomerRequest bodyRequest)
        {
            var response = await _customersService.UpdateCustomer(customerId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [HttpGet("{customerId}/cards")]
        public async Task<IActionResult> GetCustomerCards(string customerId)
        {
            var response = await _customersService.GetCustomerCards(customerId);

            return response.ReturnStatusCode(this);
        }

        [HttpGet("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> GetCustomerCardById(string customerId, string cardId)
        {
            var response = await _customersService.GetCustomerCardById(customerId, cardId);

            return response.ReturnStatusCode(this);
        }

        [HttpPost("{customerId}/cards")]
        public async Task<IActionResult> CreateCustomerCard(string customerId, [FromBody] CreateCustomerCardRequest bodyRequest)
        {
            var response = await _customersService.CreateCustomerCard(customerId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [HttpPut("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> UpdateCustomerCard(string customerId, string cardId, [FromBody] UpdateCustomerCardRequest bodyRequest)
        {
            var response = await _customersService.UpdateCustomerCard(customerId, cardId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [HttpDelete("{customerId}/cards/{cardId}")]
        public async Task<IActionResult> DeleteCustomerCard(string customerId, string cardId)
        {
            var response = await _customersService.DeleteCustomerCard(customerId, cardId);

            return response.ReturnStatusCode(this);
        }
    }
}

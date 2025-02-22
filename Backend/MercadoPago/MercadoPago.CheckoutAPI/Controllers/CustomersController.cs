using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Customers.Request;
using MercadoPago.CheckoutAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication _customersApplication;

        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchCustomers([FromQuery] SearchCustomersRequestFilters filters) 
        {
            var response = await _customersApplication.SearchCustomers(filters);

            return response.ReturnStatusCode(this);
        }


        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(string customerId) 
        {
            var response = await _customersApplication.GetCustomerById(customerId);

            return response.ReturnStatusCode(this);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest bodyRequest)
        {
            var response = await _customersApplication.CreateCustomer(bodyRequest);

            return response.ReturnStatusCode(this);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(string customerId, [FromBody] UpdateCustomerRequest bodyRequest)
        {
            var response = await _customersApplication.UpdateCustomer(customerId, bodyRequest);

            return response.ReturnStatusCode(this);
        }

        
    }
}

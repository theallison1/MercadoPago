using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Customers.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers.MercadoPago
{
    [Authorize(Roles = "administrator")]
    [Route("api/MercadoPago/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication _customersApplication;

        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchCustomers([FromQuery] CustomersRequestFilters filters)
        {
            var response = await _customersApplication.SearchCustomers<object>(filters);

            return StatusCode(response.StatusCode, response);
        }


        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(string customerId)
        {
            var response = await _customersApplication.GetCustomerById<object>(customerId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest bodyRequest)
        {
            var response = await _customersApplication.CreateCustomer<object>(bodyRequest);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(string customerId, [FromBody] CustomerRequest bodyRequest)
        {
            var response = await _customersApplication.UpdateCustomer<object>(customerId, bodyRequest);

            return StatusCode(response.StatusCode, response);
        }


    }
}

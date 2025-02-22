using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Users.Request;
using MercadoPago.CheckoutAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersApplication _usersApplication;

        public UsersController(IUsersApplication usersApplication)
        {
            _usersApplication = usersApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyUser()
        {
            var response = await _usersApplication.GetMyUser();
            
            return response.ReturnStatusCode(this);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestUser([FromBody] CreateTestUserRequest bodyRequest)
        {
            var response = await _usersApplication.CreateTestUser(bodyRequest);

            return response.ReturnStatusCode(this);
        }
    }
}

using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Users.Request;
using MercadoPago.CheckoutAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers.MercadoPago
{
    [Authorize(Roles = "administrator")]
    [Route("api/MercadoPago/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersApplication _usersApplication;

        public UsersController(IUsersApplication usersApplication)
        {
            _usersApplication = usersApplication;
        }

        [HttpGet("Me")]
        public async Task<IActionResult> GetMyUser()
        {
            var response = await _usersApplication.GetMyUser();

            return response.ReturnStatusCode(this);
        }

        [HttpPost("Test")]
        public async Task<IActionResult> CreateTestUser([FromBody] CreateTestUserRequest bodyRequest)
        {
            var response = await _usersApplication.CreateTestUser(bodyRequest);

            return response.ReturnStatusCode(this);
        }
    }
}

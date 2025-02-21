using MercadoPago.CheckoutAPI.HttpUtilities;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Users.Request;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyUser()
        {
            var response = await _usersService.GetMyUser();
            
            return response.ReturnStatusCode(this);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestUser([FromBody] CreateTestUserRequest bodyRequest)
        {
            var response = await _usersService.CreateTestUser(bodyRequest);

            return response.ReturnStatusCode(this);
        }
    }
}

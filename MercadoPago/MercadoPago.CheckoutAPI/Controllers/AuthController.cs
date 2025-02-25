using MercadoPago.CheckoutAPI.Application.Dtos.Users.Request;
using MercadoPago.CheckoutAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPago.CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApplication _authApplication;

        public AuthController(IAuthApplication authApplication)
        {
            _authApplication = authApplication;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] TokenRequestDto bodyRequest)
        {
            var response = await _authApplication.Login(bodyRequest);

            return StatusCode(response.StatusCode, response);
        }
    }
}

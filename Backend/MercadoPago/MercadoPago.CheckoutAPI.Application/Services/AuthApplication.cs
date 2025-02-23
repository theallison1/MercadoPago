using MercadoPago.CheckoutAPI.Application.Dtos.Users.Request;
using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Infrastructure.Persistences.Interfaces;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IUsersRepository _usersRepository;

        public AuthApplication(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<BaseResponse> Login(TokenRequestDto bodyRequest)
        {
            var response = new BaseResponse();

            var user = await _usersRepository.GetUserByEmail(bodyRequest.Email);

            return response;
        }
    }
}

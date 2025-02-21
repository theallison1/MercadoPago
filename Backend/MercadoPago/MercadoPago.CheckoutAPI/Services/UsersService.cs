using MercadoPago.CheckoutAPI.HttpUtilities;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.Users.Request;

namespace MercadoPago.CheckoutAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRequestHandlerService _requestHandlerService;

        public UsersService(IRequestHandlerService requestHandlerService)
        {
            _requestHandlerService = requestHandlerService;
        }


        public async Task<BaseResponse> GetMyUser()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "users/me");

            var response = await _requestHandlerService.SendAsync(request, false);

            return response;
        }

        public async Task<BaseResponse> CreateTestUser(CreateTestUserRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "users/test");

            request.AddJsonBody(bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request, false);

            return response;
        }
    }
}

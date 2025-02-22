using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Users.Request;
using MercadoPago.CheckoutAPI.Application.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRequestHandlerService _requestHandlerService;
        private readonly ISerializer _serializer;

        public UsersService(IRequestHandlerService requestHandlerService, ISerializer serializer)
        {
            _requestHandlerService = requestHandlerService;
            _serializer = serializer;
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

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request, false);

            return response;
        }
    }
}

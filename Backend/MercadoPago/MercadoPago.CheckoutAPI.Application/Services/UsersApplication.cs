using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Users.Request;
using MercadoPago.CheckoutAPI.Application.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IHttpClientManagerApplication _httpClientManagerApplication;
        private readonly ISerializer _serializer;

        public UsersApplication(IHttpClientManagerApplication httpClientManagerApplication, ISerializer serializer)
        {
            _httpClientManagerApplication = httpClientManagerApplication;
            _serializer = serializer;

            _httpClientManagerApplication.RemoveVersionUrlBase();
        }


        public async Task<BaseResponse> GetMyUser()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "users/me");

            var response = await _httpClientManagerApplication.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> CreateTestUser(CreateTestUserRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "users/test");

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _httpClientManagerApplication.SendWithRetryAsync(request);

            return response;
        }
    }
}

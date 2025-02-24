using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Users.Request;
using MercadoPago.CheckoutAPI.Application.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Services.MercadoPago
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


        public async Task<BaseResponse<T>> GetMyUser<T>()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "users/me");

            var response = await _httpClientManagerApplication.SendAsync<T>(request);

            return response;
        }

        public async Task<BaseResponse<T>> CreateTestUser<T>(CreateTestUserRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "users/test");

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _httpClientManagerApplication.SendWithRetryAsync<T>(request);

            return response;
        }
    }
}

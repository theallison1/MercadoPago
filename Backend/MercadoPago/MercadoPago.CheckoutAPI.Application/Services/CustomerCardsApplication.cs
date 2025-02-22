using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.CustomerCards.Request;
using MercadoPago.CheckoutAPI.Application.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class CustomerCardsApplication : ICustomerCardsApplication
    {
        private readonly IHttpClientManagerApplication _httpClientManagerApplication;
        private readonly ISerializer _serializer;

        public CustomerCardsApplication(IHttpClientManagerApplication httpClientManagerApplication, ISerializer serializer)
        {
            _httpClientManagerApplication = httpClientManagerApplication;
            _serializer = serializer;
        }

        public async Task<BaseResponse> GetCustomerCards(string customerId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"customers/{customerId}/cards");

            var response = await _httpClientManagerApplication.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> GetCustomerCardById(string customerId, string cardId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"customers/{customerId}/cards/{cardId}");

            var response = await _httpClientManagerApplication.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> CreateCustomerCard(string customerId, CreateCustomerCardRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"customers/{customerId}/cards");

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _httpClientManagerApplication.SendWithRetryAsync(request);

            return response;
        }

        public async Task<BaseResponse> UpdateCustomerCard(string customerId, string cardId, UpdateCustomerCardRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"customers/{customerId}/cards/{cardId}");

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _httpClientManagerApplication.SendWithRetryAsync(request);

            return response;
        }

        public async Task<BaseResponse> DeleteCustomerCard(string customerId, string cardId)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"customers/{customerId}/cards/{cardId}");

            var response = await _httpClientManagerApplication.SendWithRetryAsync(request);

            return response;
        }
    }
}

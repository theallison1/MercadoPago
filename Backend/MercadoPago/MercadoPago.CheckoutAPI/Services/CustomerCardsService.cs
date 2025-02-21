using MercadoPago.CheckoutAPI.HttpUtilities;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.CustomerCards.Request;

namespace MercadoPago.CheckoutAPI.Services
{
    public class CustomerCardsService : ICustomerCardsService
    {
        private readonly IRequestHandlerService _requestHandlerService;

        public CustomerCardsService(IRequestHandlerService requestHandlerService)
        {
            _requestHandlerService = requestHandlerService;
        }

        public async Task<BaseResponse> GetCustomerCards(string customerId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"customers/{customerId}/cards");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> GetCustomerCardById(string customerId, string cardId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"customers/{customerId}/cards/{cardId}");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> CreateCustomerCard(string customerId, CreateCustomerCardRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"customers/{customerId}/cards");

            request.AddJsonBody(bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
        }

        public async Task<BaseResponse> UpdateCustomerCard(string customerId, string cardId, UpdateCustomerCardRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"customers/{customerId}/cards/{cardId}");

            request.AddJsonBody(bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
        }

        public async Task<BaseResponse> DeleteCustomerCard(string customerId, string cardId)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"customers/{customerId}/cards/{cardId}");

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
        }
    }
}

using MercadoPago.CheckoutAPI.HttpUtilities;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.Customers.Request;

namespace MercadoPago.CheckoutAPI.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IRequestHandlerService _requestHandlerService;

        public CustomersService(IRequestHandlerService requestHandlerService)
        {
            _requestHandlerService = requestHandlerService;
        }

        public async Task<BaseResponse> SearchCustomers(SearchCustomersRequestFilters filters)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"customers/search{filters.SetQuery()}");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> GetCustomerById(string customerId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"customers/{customerId}");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> CreateCustomer(CreateCustomerRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"customers");

            request.AddJsonBody(bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
        }

        public async Task<BaseResponse> UpdateCustomer(string customerId, UpdateCustomerRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"customers/{customerId}");

            request.AddJsonBody(bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
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

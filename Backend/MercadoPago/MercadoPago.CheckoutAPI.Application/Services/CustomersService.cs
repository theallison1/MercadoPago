using MercadoPago.CheckoutAPI.Application.Helpers;
using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Customers.Request;
using MercadoPago.CheckoutAPI.Application.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IRequestHandlerService _requestHandlerService;
        private readonly ISerializer _serializer;

        public CustomersService(IRequestHandlerService requestHandlerService, ISerializer serializer)
        {
            _requestHandlerService = requestHandlerService;
            _serializer = serializer;
        }

        public async Task<BaseResponse> SearchCustomers(SearchCustomersRequestFilters filters)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"customers/search{_serializer.SetQueryParams(filters)}");

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

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
        }

        public async Task<BaseResponse> UpdateCustomer(string customerId, UpdateCustomerRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"customers/{customerId}");

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
        }


    }
}

using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Customers.Request;
using MercadoPago.CheckoutAPI.Application.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Services.MercadoPago
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly IHttpClientManagerApplication _httpClientManagerApplication;
        private readonly ISerializer _serializer;

        public CustomersApplication(IHttpClientManagerApplication httpClientManagerApplication, ISerializer serializer)
        {
            _httpClientManagerApplication = httpClientManagerApplication;
            _serializer = serializer;
        }

        public async Task<BaseResponse<T>> SearchCustomers<T>(SearchCustomersRequestFilters filters)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"customers/search{_serializer.SetQueryParams(filters)}");

            var response = await _httpClientManagerApplication.SendAsync<T>(request);

            return response;
        }

        public async Task<BaseResponse<T>> GetCustomerById<T>(string customerId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"customers/{customerId}");

            var response = await _httpClientManagerApplication.SendAsync<T>(request);

            return response;
        }

        public async Task<BaseResponse<T>> CreateCustomer<T>(CreateCustomerRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"customers");

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _httpClientManagerApplication.SendWithRetryAsync<T>(request);

            return response;
        }

        public async Task<BaseResponse<T>> UpdateCustomer<T>(string customerId, UpdateCustomerRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"customers/{customerId}");

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _httpClientManagerApplication.SendWithRetryAsync<T>(request);

            return response;
        }


    }
}

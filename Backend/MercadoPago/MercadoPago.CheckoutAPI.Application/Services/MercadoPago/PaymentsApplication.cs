using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Payments.Request;
using MercadoPago.CheckoutAPI.Application.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Services.MercadoPago
{
    public class PaymentsApplication : IPaymentsApplication
    {
        private readonly IHttpClientManagerApplication _httpClientManagerApplication;
        private readonly ISerializer _serializer;

        public PaymentsApplication(IHttpClientManagerApplication httpClientManagerApplication, ISerializer serializer)
        {
            _httpClientManagerApplication = httpClientManagerApplication;
            _serializer = serializer;
        }

        public async Task<BaseResponse<T>> SearchPayments<T>(SearchPaymentsRequestFilters filters)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"payments/search{_serializer.SetQueryParams(filters)}");

            var response = await _httpClientManagerApplication.SendAsync<T>(request);

            return response;
        }

        public async Task<BaseResponse<T>> GetPaymentById<T>(int paymentId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"payments/{paymentId}");

            var response = await _httpClientManagerApplication.SendAsync<T>(request);

            return response;
        }

        public async Task<BaseResponse<T>> CreatePayment<T>(CreatePaymentRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"payments");

            _httpClientManagerApplication.AddXIdempotencyKey(request.Headers);
            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _httpClientManagerApplication.SendWithRetryAsync<T>(request);

            return response;
        }

        public async Task<BaseResponse<T>> UpdatePayment<T>(int paymentId, UpdatePaymentRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"payments/{paymentId}");

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _httpClientManagerApplication.SendWithRetryAsync<T>(request);

            return response;
        }
    }
}

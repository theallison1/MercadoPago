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

        public async Task<BaseResponse<T>> SearchPayments<T>(PaymentsRequestFilters filters)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"payments/search{_serializer.SetQueryParams(filters)}");
            var httpResponse = await _httpClientManagerApplication.SendAsync(httpRequest);

            var response = await _httpClientManagerApplication.SetBaseResponse<T>(httpResponse);
            return response;
        }

        public async Task<BaseResponse<T>> GetPaymentById<T>(int paymentId)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"payments/{paymentId}");
            var httpResponse = await _httpClientManagerApplication.SendAsync(httpRequest);

            var response = await _httpClientManagerApplication.SetBaseResponse<T>(httpResponse);
            return response;
        }

        public async Task<BaseResponse<T>> CreatePayment<T>(PaymentRequest bodyRequest)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"payments");
            _httpClientManagerApplication.AddXIdempotencyKey(httpRequest.Headers);
            _serializer.AddJsonBodyToContent(httpRequest, bodyRequest);
            var httpResponse = await _httpClientManagerApplication.SendWithRetryAsync(httpRequest);

            var response = await _httpClientManagerApplication.SetBaseResponse<T>(httpResponse);
            return response;
        }

        public async Task<BaseResponse<T>> UpdatePayment<T>(int paymentId, PaymentRequest bodyRequest)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Put, $"payments/{paymentId}");
            _serializer.AddJsonBodyToContent(httpRequest, bodyRequest);
            var httpResponse = await _httpClientManagerApplication.SendWithRetryAsync(httpRequest);

            var response = await _httpClientManagerApplication.SetBaseResponse<T>(httpResponse);
            return response;
        }
    }
}

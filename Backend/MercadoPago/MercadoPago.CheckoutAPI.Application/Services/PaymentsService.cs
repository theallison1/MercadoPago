using MercadoPago.CheckoutAPI.Application.Helpers;
using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Payments.Request;
using MercadoPago.CheckoutAPI.Application.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IRequestHandlerService _requestHandlerService;
        private readonly ISerializer _serializer;

        public PaymentsService(IRequestHandlerService requestHandlerService, ISerializer serializer)
        {
            _requestHandlerService = requestHandlerService;
            _serializer = serializer;
        }

        public async Task<BaseResponse> SearchPayments(SearchPaymentsRequestFilters filters)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"payments/search{_serializer.SetQueryParams(filters)}");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> GetPaymentById(int paymentId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"payments/{paymentId}");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> CreatePayment(CreatePaymentRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"payments");

            request.Headers.AddXIdempotencyKey();
            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
        }

        public async Task<BaseResponse> UpdatePayment(int paymentId, UpdatePaymentRequest bodyRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"payments/{paymentId}");

            _serializer.AddJsonBodyToContent(request, bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
        }
    }
}

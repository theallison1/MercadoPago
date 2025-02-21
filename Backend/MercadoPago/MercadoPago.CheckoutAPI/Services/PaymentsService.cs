using MercadoPago.CheckoutAPI.HttpUtilities;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.Payments.Request;

namespace MercadoPago.CheckoutAPI.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IRequestHandlerService _requestHandlerService;

        public PaymentsService(IRequestHandlerService requestHandlerService)
        {
            _requestHandlerService = requestHandlerService;
        }

        public async Task<BaseResponse> SearchPayments(SearchPaymentsRequestFilters filters)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"payments/search{filters.SetQuery()}");

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
            request.AddJsonBody(bodyRequest);

            var response = await _requestHandlerService.SendWithRetryAsync(request);

            return response;
        }
    }
}

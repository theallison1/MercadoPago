using MercadoPago.CheckoutAPI.Helpers;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Request;
using MercadoPago.CheckoutAPI.Models.Response;

namespace MercadoPago.CheckoutAPI.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IRequestHandlerService _requestHandlerService;

        public PaymentsService(IRequestHandlerService requestHandlerService)
        {
            _requestHandlerService = requestHandlerService;
        }

        public async Task<BaseResponse> GetPayments(GetPaymentsRequestFilters filters)
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
    }
}

using MercadoPago.CheckoutAPI.Interfaces;
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

        public async Task<BaseResponse> GetPaymentById(int paymentId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"payments/{paymentId}");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> GetPaymentByExternalReference(string externalReference)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"payments/search?external_reference={externalReference}");

            var response = await _requestHandlerService.SendAsync(request);
       
            return response;
        }
    }
}

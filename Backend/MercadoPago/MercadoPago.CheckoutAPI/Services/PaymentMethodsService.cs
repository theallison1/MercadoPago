using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Commons.Response;

namespace MercadoPago.CheckoutAPI.Services
{
    public class PaymentMethodsService : IPaymentMethodsService
    {
        private readonly IRequestHandlerService _requestHandlerService;

        public PaymentMethodsService(IRequestHandlerService requestHandlerService)
        {
            _requestHandlerService = requestHandlerService;
        }

        public async Task<BaseResponse> GetPaymentMethods()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "payment_methods");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }
    }
}

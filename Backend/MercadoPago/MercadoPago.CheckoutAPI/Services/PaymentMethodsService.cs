using MercadoPago.CheckoutAPI.HttpUtilities;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.PaymentMethods.Request;
using MercadoPago.CheckoutAPI.Settings;
using Microsoft.Extensions.Options;

namespace MercadoPago.CheckoutAPI.Services
{
    public class PaymentMethodsService : IPaymentMethodsService
    {
        private readonly IRequestHandlerService _requestHandlerService;
        private readonly IOptions<MercadoPagoSettings> _options;

        public PaymentMethodsService(IRequestHandlerService requestHandlerService, IOptions<MercadoPagoSettings> options)
        {
            _requestHandlerService = requestHandlerService;
            _options = options;
        }

        public async Task<BaseResponse> SearchPaymentMethods(SearchPaymentMethodsRequestFilters filters)
        {
            filters.PublicKey = _options.Value.PublicKey;
            var request = new HttpRequestMessage(HttpMethod.Get, $"payment_methods/search{filters.SetQuery()}");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> GetPaymentMethods()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "payment_methods");

            var response = await _requestHandlerService.SendAsync(request);

            return response;
        }
    }
}

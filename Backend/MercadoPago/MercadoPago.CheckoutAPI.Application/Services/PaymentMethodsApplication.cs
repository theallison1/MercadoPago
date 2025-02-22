using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.PaymentMethods.Request;
using MercadoPago.CheckoutAPI.Application.Serialization;
using MercadoPago.CheckoutAPI.Application.Settings;
using Microsoft.Extensions.Options;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class PaymentMethodsApplication : IPaymentMethodsApplication
    {
        private readonly IHttpClientManagerApplication _httpClientManagerApplication;
        private readonly ISerializer _serializer;
        private readonly IOptions<MercadoPagoSettings> _options;

        public PaymentMethodsApplication(IHttpClientManagerApplication httpClientManagerApplication, ISerializer serializer, IOptions<MercadoPagoSettings> options)
        {
            _httpClientManagerApplication = httpClientManagerApplication;
            _serializer = serializer;
            _options = options;
        }

        public async Task<BaseResponse> SearchPaymentMethods(SearchPaymentMethodsRequestFilters filters)
        {
            filters.PublicKey = _options.Value.PublicKey;
            var request = new HttpRequestMessage(HttpMethod.Get, $"payment_methods/search{_serializer.SetQueryParams(filters)}");

            var response = await _httpClientManagerApplication.SendAsync(request);

            return response;
        }

        public async Task<BaseResponse> GetPaymentMethods()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "payment_methods");

            var response = await _httpClientManagerApplication.SendAsync(request);

            return response;
        }
    }
}

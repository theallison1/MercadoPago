using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class IdentificationTypesApplication : IIdentificationTypesApplication
    {
        private readonly IHttpClientManagerApplication _httpClientManagerApplication;

        public IdentificationTypesApplication(IHttpClientManagerApplication httpClientManagerApplication)
        {
            _httpClientManagerApplication = httpClientManagerApplication;
        }

        public async Task<BaseResponse<HttpResponseMessage>> GetIdentificationTypes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "identification_types");

            var response = await _httpClientManagerApplication.SendAsync(request);

            return response;
        }
    }
}

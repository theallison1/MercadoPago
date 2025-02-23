using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using System.Net.Http.Headers;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IHttpClientManagerApplication
    {
        Task<BaseResponse<HttpResponseMessage>> SendAsync(HttpRequestMessage request);
        Task<BaseResponse<HttpResponseMessage>> SendWithRetryAsync(HttpRequestMessage request);
        HttpRequestHeaders AddXIdempotencyKey(HttpRequestHeaders headers);
        void RemoveVersionUrlBase();
    }
}

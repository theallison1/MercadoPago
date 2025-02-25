using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using System.Net.Http.Headers;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IHttpClientManagerApplication
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequest);
        Task<HttpResponseMessage> SendWithRetryAsync(HttpRequestMessage httpRequest);
        Task<BaseResponse<T>> SetBaseResponse<T>(HttpResponseMessage httpResponse);
        HttpRequestHeaders AddXIdempotencyKey(HttpRequestHeaders headers);
        void RemoveVersionUrlBase();
    }
}

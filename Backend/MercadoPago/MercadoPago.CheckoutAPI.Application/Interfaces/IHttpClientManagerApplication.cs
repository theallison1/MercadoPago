using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using System.Net.Http.Headers;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IHttpClientManagerApplication
    {
        Task<BaseResponse> SendAsync(HttpRequestMessage request);
        Task<BaseResponse> SendWithRetryAsync(HttpRequestMessage request);
        HttpRequestHeaders AddXIdempotencyKey(HttpRequestHeaders headers);
        void RemoveVersionUrlBase();
    }
}

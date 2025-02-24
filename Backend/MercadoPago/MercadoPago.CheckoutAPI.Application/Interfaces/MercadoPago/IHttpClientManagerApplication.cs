using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using System.Net.Http.Headers;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IHttpClientManagerApplication
    {
        Task<BaseResponse<T>> SendAsync<T>(HttpRequestMessage request);
        Task<BaseResponse<T>> SendWithRetryAsync<T>(HttpRequestMessage request);
        HttpRequestHeaders AddXIdempotencyKey(HttpRequestHeaders headers);
        void RemoveVersionUrlBase();
    }
}

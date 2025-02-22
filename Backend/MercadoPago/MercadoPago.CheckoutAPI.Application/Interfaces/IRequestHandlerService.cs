using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IRequestHandlerService
    {
        Task<BaseResponse> SendAsync(HttpRequestMessage request);
        Task<BaseResponse> SendWithRetryAsync(HttpRequestMessage request);
        void RemoveVersionUrlBase();
    }
}

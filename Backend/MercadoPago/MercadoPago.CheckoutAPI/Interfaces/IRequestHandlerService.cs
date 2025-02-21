using MercadoPago.CheckoutAPI.Models.Commons.Response;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface IRequestHandlerService
    {
        Task<BaseResponse> SendAsync(HttpRequestMessage request, bool apiVersioned = true);
        Task<BaseResponse> SendWithRetryAsync(HttpRequestMessage request, bool apiVersioned = true);
        void ValidateUrlBase(bool apiVersioned);
    }
}

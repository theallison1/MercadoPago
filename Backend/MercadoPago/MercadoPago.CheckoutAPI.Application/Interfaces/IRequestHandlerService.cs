using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IRequestHandlerService
    {
        Task<BaseResponse> SendAsync(HttpRequestMessage request, bool apiVersioned = true);
        Task<BaseResponse> SendWithRetryAsync(HttpRequestMessage request, bool apiVersioned = true);
        void ValidateUrlBase(bool apiVersioned);
    }
}

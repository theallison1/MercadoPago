using MercadoPago.CheckoutAPI.Models.Commons.Response;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface IRequestHandlerService
    {
        Task<BaseResponse> SendAsync(HttpRequestMessage request);
        Task<BaseResponse> SendWithRetryAsync(HttpRequestMessage request, int maxRetries = 3, int delayMilliseconds = 1000);
    }
}

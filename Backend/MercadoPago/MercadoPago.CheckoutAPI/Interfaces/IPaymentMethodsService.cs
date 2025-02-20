using MercadoPago.CheckoutAPI.Models.Commons.Response;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface IPaymentMethodsService
    {
        Task<BaseResponse> GetPaymentMethods();
    }
}

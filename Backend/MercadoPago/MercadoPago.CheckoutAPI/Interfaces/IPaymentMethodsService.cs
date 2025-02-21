using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.PaymentMethods.Request;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface IPaymentMethodsService
    {
        Task<BaseResponse> SearchPaymentMethods(SearchPaymentMethodsRequestFilters filters);
        Task<BaseResponse> GetPaymentMethods();
    }
}

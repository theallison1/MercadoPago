using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.PaymentMethods.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IPaymentMethodsService
    {
        Task<BaseResponse> SearchPaymentMethods(SearchPaymentMethodsRequestFilters filters);
        Task<BaseResponse> GetPaymentMethods();
    }
}

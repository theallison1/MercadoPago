using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.PaymentMethods.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface IPaymentMethodsApplication
    {
        Task<BaseResponse<object>> SearchPaymentMethods(PaymentMethodsRequestFilters filters);
        Task<BaseResponse<object>> GetPaymentMethods();
        Task<BaseResponse<object>> GetInstallments(PaymentMethodsRequestFilters filters);
    }
}

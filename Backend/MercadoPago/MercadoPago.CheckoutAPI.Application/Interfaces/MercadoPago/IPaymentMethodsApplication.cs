using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.PaymentMethods.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface IPaymentMethodsApplication
    {
        Task<BaseResponse<HttpResponseMessage>> SearchPaymentMethods(SearchPaymentMethodsRequestFilters filters);
        Task<BaseResponse<HttpResponseMessage>> GetPaymentMethods();
    }
}

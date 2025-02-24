using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Payments.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface IPaymentsApplication
    {
        Task<BaseResponse<HttpResponseMessage>> SearchPayments(SearchPaymentsRequestFilters filters);
        Task<BaseResponse<HttpResponseMessage>> GetPaymentById(int paymentId);
        Task<BaseResponse<HttpResponseMessage>> CreatePayment(CreatePaymentRequest bodyRequest);
        Task<BaseResponse<HttpResponseMessage>> UpdatePayment(int paymentId, UpdatePaymentRequest bodyRequest);
    }
}

using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Payments.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface IPaymentsApplication
    {
        Task<BaseResponse<object>> SearchPayments(PaymentsRequestFilters filters);
        Task<BaseResponse<object>> GetPaymentById(int paymentId);
        Task<BaseResponse<object>> CreatePayment(PaymentRequest bodyRequest);
        Task<BaseResponse<object>> UpdatePayment(int paymentId, PaymentRequest bodyRequest);
    }
}

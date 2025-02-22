using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Payments.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IPaymentsApplication
    {
        Task<BaseResponse> SearchPayments(SearchPaymentsRequestFilters filters);
        Task<BaseResponse> GetPaymentById(int paymentId);
        Task<BaseResponse> CreatePayment(CreatePaymentRequest bodyRequest);
        Task<BaseResponse> UpdatePayment(int paymentId, UpdatePaymentRequest bodyRequest);
    }
}

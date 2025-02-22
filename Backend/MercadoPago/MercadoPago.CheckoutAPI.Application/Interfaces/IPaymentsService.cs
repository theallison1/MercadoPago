using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Payments.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IPaymentsService
    {
        Task<BaseResponse> SearchPayments(SearchPaymentsRequestFilters filters);
        Task<BaseResponse> GetPaymentById(int paymentId);
        Task<BaseResponse> CreatePayment(CreatePaymentRequest bodyRequest);
    }
}

using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.Payments.Request;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface IPaymentsService
    {
        Task<BaseResponse> SearchPayments(SearchPaymentsRequestFilters filters);
        Task<BaseResponse> GetPaymentById(int paymentId);
        Task<BaseResponse> CreatePayment(CreatePaymentRequest bodyRequest);
    }
}

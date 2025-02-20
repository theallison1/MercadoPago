using MercadoPago.CheckoutAPI.Models.Request;
using MercadoPago.CheckoutAPI.Models.Response;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface IPaymentsService
    {
        Task<BaseResponse> GetPaymentById(int paymentId);
        Task<BaseResponse> GetPayments(GetPaymentsRequestFilters filters);
    }
}

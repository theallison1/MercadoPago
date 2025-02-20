using MercadoPago.CheckoutAPI.Models.Request;
using MercadoPago.CheckoutAPI.Models.Response;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface IPaymentsService
    {
        Task<BaseResponse> SearchPayments(SearchPaymentsRequestFilters filters);
        Task<BaseResponse> GetPaymentById(int paymentId);
    }
}

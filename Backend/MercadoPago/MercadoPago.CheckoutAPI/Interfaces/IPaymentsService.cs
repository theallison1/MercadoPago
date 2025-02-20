using MercadoPago.CheckoutAPI.Models.Response;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface IPaymentsService
    {
        Task<BaseResponse> GetPaymentById(int paymentId);
        Task<BaseResponse> GetPaymentByExternalReference(string externalReference);
    }
}

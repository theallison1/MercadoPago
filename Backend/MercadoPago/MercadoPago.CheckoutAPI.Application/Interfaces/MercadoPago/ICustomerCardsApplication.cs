using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.CustomerCards.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface ICustomerCardsApplication
    {
        Task<BaseResponse<T>> GetCustomerCards<T>(string customerId);
        Task<BaseResponse<T>> GetCustomerCardById<T>(string customerId, string cardId);
        Task<BaseResponse<T>> CreateCustomerCard<T>(string customerId, CustomerCardRequest bodyRequest);
        Task<BaseResponse<T>> UpdateCustomerCard<T>(string customerId, string cardId, CustomerCardRequest bodyRequest);
        Task<BaseResponse<T>> DeleteCustomerCard<T>(string customerId, string cardId);
    }
}

using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.CustomerCards.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface ICustomerCardsApplication
    {
        Task<BaseResponse<object>> GetCustomerCards(string customerId);
        Task<BaseResponse<object>> GetCustomerCardById(string customerId, string cardId);
        Task<BaseResponse<object>> CreateCustomerCard(string customerId, CustomerCardRequest bodyRequest);
        Task<BaseResponse<object>> UpdateCustomerCard(string customerId, string cardId, CustomerCardRequest bodyRequest);
        Task<BaseResponse<object>> DeleteCustomerCard(string customerId, string cardId);
    }
}

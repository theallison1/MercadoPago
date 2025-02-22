using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.CustomerCards.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface ICustomerCardsApplication
    {
        Task<BaseResponse> GetCustomerCards(string customerId);
        Task<BaseResponse> GetCustomerCardById(string customerId, string cardId);
        Task<BaseResponse> CreateCustomerCard(string customerId, CreateCustomerCardRequest bodyRequest);
        Task<BaseResponse> UpdateCustomerCard(string customerId, string cardId, UpdateCustomerCardRequest bodyRequest);
        Task<BaseResponse> DeleteCustomerCard(string customerId, string cardId);
    }
}

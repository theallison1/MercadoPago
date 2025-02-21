using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.CustomerCards.Request;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface ICustomerCardsService
    {
        Task<BaseResponse> GetCustomerCards(string customerId);
        Task<BaseResponse> GetCustomerCardById(string customerId, string cardId);
        Task<BaseResponse> CreateCustomerCard(string customerId, CreateCustomerCardRequest bodyRequest);
        Task<BaseResponse> UpdateCustomerCard(string customerId, string cardId, UpdateCustomerCardRequest bodyRequest);
        Task<BaseResponse> DeleteCustomerCard(string customerId, string cardId);
    }
}

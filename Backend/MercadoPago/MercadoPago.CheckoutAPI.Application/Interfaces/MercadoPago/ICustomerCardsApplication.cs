using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.CustomerCards.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface ICustomerCardsApplication
    {
        Task<BaseResponse<HttpResponseMessage>> GetCustomerCards(string customerId);
        Task<BaseResponse<HttpResponseMessage>> GetCustomerCardById(string customerId, string cardId);
        Task<BaseResponse<HttpResponseMessage>> CreateCustomerCard(string customerId, CreateCustomerCardRequest bodyRequest);
        Task<BaseResponse<HttpResponseMessage>> UpdateCustomerCard(string customerId, string cardId, UpdateCustomerCardRequest bodyRequest);
        Task<BaseResponse<HttpResponseMessage>> DeleteCustomerCard(string customerId, string cardId);
    }
}

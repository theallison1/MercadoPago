using MercadoPago.CheckoutAPI.Models.Request;
using MercadoPago.CheckoutAPI.Models.Response;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface ICustomersService
    {
        Task<BaseResponse> SearchCustomers(SearchCustomersRequestFilters filters);
        Task<BaseResponse> GetCustomerById(string customerId);
        Task<BaseResponse> GetCustomerCards(string customerId);
        Task<BaseResponse> GetCustomerCardById(string customerId, string cardId);
    }
}

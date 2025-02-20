using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.Customers.Request;

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

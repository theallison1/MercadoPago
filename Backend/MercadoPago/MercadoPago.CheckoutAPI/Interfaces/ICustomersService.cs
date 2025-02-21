using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.Customers.Request;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface ICustomersService
    {
        Task<BaseResponse> SearchCustomers(SearchCustomersRequestFilters filters);
        Task<BaseResponse> GetCustomerById(string customerId);
        Task<BaseResponse> CreateCustomer(CreateCustomerRequest bodyRequest);
        Task<BaseResponse> UpdateCustomer(string customerId, UpdateCustomerRequest bodyRequest);
    }
}

using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Customers.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface ICustomersApplication
    {
        Task<BaseResponse> SearchCustomers(SearchCustomersRequestFilters filters);
        Task<BaseResponse> GetCustomerById(string customerId);
        Task<BaseResponse> CreateCustomer(CreateCustomerRequest bodyRequest);
        Task<BaseResponse> UpdateCustomer(string customerId, UpdateCustomerRequest bodyRequest);
    }
}

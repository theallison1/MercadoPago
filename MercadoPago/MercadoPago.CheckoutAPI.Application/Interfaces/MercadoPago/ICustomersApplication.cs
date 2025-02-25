using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Customers.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface ICustomersApplication
    {
        Task<BaseResponse<T>> SearchCustomers<T>(CustomersRequestFilters filters);
        Task<BaseResponse<T>> GetCustomerById<T>(string customerId);
        Task<BaseResponse<T>> CreateCustomer<T>(CustomerRequest bodyRequest);
        Task<BaseResponse<T>> UpdateCustomer<T>(string customerId, CustomerRequest bodyRequest);
    }
}

using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Customers.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface ICustomersApplication
    {
        Task<BaseResponse<object>> SearchCustomers(CustomersRequestFilters filters);
        Task<BaseResponse<object>> GetCustomerById(string customerId);
        Task<BaseResponse<object>> CreateCustomer(CustomerRequest bodyRequest);
        Task<BaseResponse<object>> UpdateCustomer(string customerId, CustomerRequest bodyRequest);
    }
}

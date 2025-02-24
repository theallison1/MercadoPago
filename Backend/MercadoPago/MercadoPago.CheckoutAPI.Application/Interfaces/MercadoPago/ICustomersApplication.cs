using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Customers.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface ICustomersApplication
    {
        Task<BaseResponse<HttpResponseMessage>> SearchCustomers(SearchCustomersRequestFilters filters);
        Task<BaseResponse<HttpResponseMessage>> GetCustomerById(string customerId);
        Task<BaseResponse<HttpResponseMessage>> CreateCustomer(CreateCustomerRequest bodyRequest);
        Task<BaseResponse<HttpResponseMessage>> UpdateCustomer(string customerId, UpdateCustomerRequest bodyRequest);
    }
}

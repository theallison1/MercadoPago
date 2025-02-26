using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Users.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface IUsersApplication
    {
        Task<BaseResponse<object>> GetMyUser();
        Task<BaseResponse<object>> CreateTestUser(CreateTestUserRequest bodyRequest);
    }
}

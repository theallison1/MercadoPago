using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Users.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IUsersService
    {
        Task<BaseResponse> GetMyUser();
        Task<BaseResponse> CreateTestUser(CreateTestUserRequest bodyRequest);
    }
}

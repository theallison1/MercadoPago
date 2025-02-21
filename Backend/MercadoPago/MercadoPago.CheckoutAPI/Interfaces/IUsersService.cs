using MercadoPago.CheckoutAPI.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Models.Users.Request;

namespace MercadoPago.CheckoutAPI.Interfaces
{
    public interface IUsersService
    {
        Task<BaseResponse> GetMyUser();
        Task<BaseResponse> CreateTestUser(CreateTestUserRequest bodyRequest);
    }
}

using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Models.Users.Request;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IUsersApplication
    {
        Task<BaseResponse<HttpResponseMessage>> GetMyUser();
        Task<BaseResponse<HttpResponseMessage>> CreateTestUser(CreateTestUserRequest bodyRequest);
    }
}

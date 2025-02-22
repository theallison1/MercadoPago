using MercadoPago.CheckoutAPI.Application.Models.CardToken.Request;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface ICardTokensApplication
    {
        Task<BaseResponse> CreateCardToken(CreateCardTokenRequest bodyRequest);
    }
}

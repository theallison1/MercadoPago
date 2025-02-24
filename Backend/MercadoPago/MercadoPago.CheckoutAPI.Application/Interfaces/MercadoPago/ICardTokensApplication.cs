using MercadoPago.CheckoutAPI.Application.Models.CardToken.Request;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;

namespace MercadoPago.CheckoutAPI.Application.Interfaces.MercadoPago
{
    public interface ICardTokensApplication
    {
        Task<BaseResponse<HttpResponseMessage>> CreateCardToken(CreateCardTokenRequest bodyRequest);
    }
}

using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace MercadoPago.CheckoutAPI.Middlewares
{
    public class CustomAuthorizationHandler : IAuthorizationMiddlewareResultHandler
    {
        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Challenged || authorizeResult.Forbidden)
            {
                var response = new BaseResponse<object>();
                var statusCode = authorizeResult.Challenged ? StatusCodes.Status401Unauthorized : StatusCodes.Status403Forbidden;
                response.StatusCode = statusCode;
                response.Message = ReplyMessages.SetStatusCodeMessage(statusCode);
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(response);
                return;
            }

            await next(context);
        }
    }
}

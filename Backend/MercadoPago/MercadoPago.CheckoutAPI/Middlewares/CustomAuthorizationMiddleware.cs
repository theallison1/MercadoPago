using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using Microsoft.AspNetCore.Http;
using MercadoPago.CheckoutAPI.Helpers;
using Microsoft.AspNetCore.Authentication;

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
                response.Message = StatusCodeHelper.SetResponseMessage(statusCode);
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(response);
                return;
            }

            await next(context);
        }
    }
}

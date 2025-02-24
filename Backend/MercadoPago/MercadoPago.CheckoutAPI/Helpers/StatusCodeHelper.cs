using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MercadoPago.CheckoutAPI.Helpers
{
    public static class StatusCodeHelper
    {
        public static IActionResult ReturnStatusCode<T>(this BaseResponse<T> response, ControllerBase controller)
        {
            int statusCode = response.StatusCode;

            response.Message = SetResponseMessage(statusCode);

            return statusCode switch
            {
                StatusCodes.Status400BadRequest => controller.BadRequest(response),
                StatusCodes.Status401Unauthorized => controller.Unauthorized(response),
                StatusCodes.Status404NotFound => controller.NotFound(response),
                _ => controller.StatusCode(statusCode, response),
            };
        }

        public static string SetResponseMessage(int statusCode)
        {
            string message = statusCode switch
            {
                StatusCodes.Status400BadRequest => "Solicitud incorrecta. Verifique los parámetros y vuelva a intentarlo.",
                StatusCodes.Status401Unauthorized => "Acceso no autorizado. Debe iniciar sesión.",
                StatusCodes.Status403Forbidden => "Acceso denegado. No tiene permisos para acceder al recurso solicitado.",
                StatusCodes.Status404NotFound => "No se encontraron datos.",
                StatusCodes.Status405MethodNotAllowed => $"Método no permitido.",
                >= StatusCodes.Status406NotAcceptable => "Ha ocurrido un error, intente mas tarde.",
                _ => "Respuesta exitosa"
            };

            return message;
        }
    }
}

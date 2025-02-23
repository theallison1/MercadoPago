using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MercadoPago.CheckoutAPI.Helpers
{
    public static class StatusCodeHelper
    {
        public static IActionResult ReturnStatusCode(this BaseResponse<HttpResponseMessage> response, ControllerBase controller)
        {
            if (response.Data is null)
            {
                response.Message = "Error inesperado";
                return controller.StatusCode(500, response);
            }

            var statusCode = response.Data.StatusCode;

            response.StatusCode = (int)statusCode;
            response.Method = response.Data.RequestMessage.Method.Method;
            
            response.Message = statusCode switch
            {
                HttpStatusCode.BadRequest => "Solicitud incorrecta. Verifique los parámetros y vuelva a intentarlo.",
                HttpStatusCode.Unauthorized => "Acceso no autorizado",
                HttpStatusCode.Forbidden => "No tiene permisos para acceder al recurso solicitado",
                HttpStatusCode.NotFound => "No se encontraron datos",
                HttpStatusCode.MethodNotAllowed => $"Método no permitido: {response.Method}",
                >= HttpStatusCode.RequestTimeout => "Ha ocurrido un error, intente mas tarde",
                _ => "Respuesta exitosa"
            };

            return statusCode switch
            {
                HttpStatusCode.BadRequest => controller.BadRequest(response),
                HttpStatusCode.Unauthorized => controller.Unauthorized(response),
                HttpStatusCode.Forbidden => controller.StatusCode(403, response),
                HttpStatusCode.NotFound => controller.NotFound(response),
                >= HttpStatusCode.MethodNotAllowed => controller.StatusCode((int)statusCode, response),
                _ => controller.Ok(response)
            };
        }
    }
}

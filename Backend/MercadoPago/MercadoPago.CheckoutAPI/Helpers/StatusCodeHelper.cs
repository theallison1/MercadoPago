using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MercadoPago.CheckoutAPI.Helpers
{
    public static class StatusCodeHelper
    {
        public static IActionResult ReturnStatusCode(this BaseResponse response, ControllerBase controller)
        {
            if (response.Data is null)
            {
                response.Message = "Error inesperado";
                return controller.StatusCode(500, response);
            }

            var statusCode = response.Data.StatusCode;

            response.Message = statusCode switch
            {
                HttpStatusCode.BadRequest => "Solicitud incorrecta. Verifique los parámetros y vuelva a intentarlo.",
                HttpStatusCode.Unauthorized => "Acceso no autorizado",
                HttpStatusCode.NotFound => "No se encontraron datos",
                >= HttpStatusCode.RequestTimeout => "Ha ocurrido un error, intente mas tarde",
                _ => "Respuesta exitosa"
            };

            return statusCode switch
            {
                HttpStatusCode.BadRequest => controller.BadRequest(response),
                HttpStatusCode.Unauthorized => controller.Unauthorized(response),
                HttpStatusCode.NotFound => controller.NotFound(response),
                >= HttpStatusCode.RequestTimeout => controller.StatusCode((int)statusCode, response),
                _ => controller.Ok(response)
            };
        }
    }
}

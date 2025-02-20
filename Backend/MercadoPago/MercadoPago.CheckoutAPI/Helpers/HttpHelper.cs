using MercadoPago.CheckoutAPI.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace MercadoPago.CheckoutAPI.Helpers
{
    public static class HttpHelper
    {
        public static void ValidateStatusCodeMessage(this BaseResponse response)
        {
            if (response.Data is null) 
            {  
                response.Message = "Error inesperado";
                return;
            }

            response.Message = response.Data.StatusCode switch
            {
                HttpStatusCode.BadRequest => "Solicitud incorrecta. Verifique los parámetros y vuelva a intentarlo.",
                HttpStatusCode.Unauthorized => "Acceso no autorizado",
                HttpStatusCode.NotFound => "No se encontraron datos",
                >= HttpStatusCode.RequestTimeout => "Ha ocurrido un error, intente mas tarde",
                _ => "Respuesta exitosa"
            };
        }

        public static IActionResult ReturnStatusCode(this BaseResponse response, ControllerBase controller)
        {
            if (response.Data is null)
            {
                response.Message = "Error inesperado";
                return controller.StatusCode(500, response);
            }

            return response.Data.StatusCode switch
            {
                HttpStatusCode.BadRequest => controller.BadRequest(response),
                HttpStatusCode.Unauthorized => controller.Unauthorized(response),
                HttpStatusCode.NotFound => controller.NotFound(response),
                >= HttpStatusCode.RequestTimeout => controller.StatusCode((int)response.Data.StatusCode, response),
                _ => controller.Ok(response)
            };
        }

        public static async Task<object?> GetContentAsync(this HttpResponseMessage response, ILogger _logger)
        {
            if (response is null || response.Content is null)
                return null;

            try
            {
                using var jsonStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<object?>(jsonStream);
            }
            catch (JsonException ex)
            {
                _logger.LogError("Error de deserialización: {Exception}", ex);
                return null;
            }
        }
    }
}

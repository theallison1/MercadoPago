using MercadoPago.CheckoutAPI.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        public static async Task<HttpRequestMessage> CloneAsync(this HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Content = request.Content is not null ? await request.Content.CloneAsync().ConfigureAwait(false) : null,
                Version = request.Version
            };

            foreach (var header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }

        private static async Task<HttpContent> CloneAsync(this HttpContent content)
        {
            if (content is null) 
                return null!;

            var memoryStream = new MemoryStream();
            await content.CopyToAsync(memoryStream).ConfigureAwait(false);
            memoryStream.Position = 0;

            HttpContent clone = content switch
            {
                StringContent => new StringContent(await content.ReadAsStringAsync().ConfigureAwait(false)),
                ByteArrayContent => new ByteArrayContent(await content.ReadAsByteArrayAsync().ConfigureAwait(false)),
                _ => new StreamContent(memoryStream)
            };

            foreach (var header in content.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }

        public static string SetQuery<T>(this T filters)
        {
            StringBuilder query = new StringBuilder().Append("");

            if (filters is null)
                return query.ToString();
            
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(filters); 
                if (value is not null) 
                {
                    var name = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name;

                    if (query.Length > 0)
                    {
                        query.Append("&");
                    }

                    query.Append($"{name}={Uri.EscapeDataString(value.ToString())}"); 
                }
            }

            if (query.Length > 0) 
            { 
                query.Insert(0, "?");
            }

            return query.ToString();
        }
    }
}

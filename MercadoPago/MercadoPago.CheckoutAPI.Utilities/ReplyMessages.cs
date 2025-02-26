using Microsoft.AspNetCore.Http;

namespace MercadoPago.CheckoutAPI.Utilities
{
    public static class ReplyMessages
    {
        public const string TokenGeneratedSuccessfully = "Token generado correctamente";
        public const string InvalidUserPassword = "Usuario y/o contraseña invalidos";

        public static string SetStatusCodeMessage(int statusCode)
        {
            string message = statusCode switch
            {
                StatusCodes.Status400BadRequest => "Solicitud incorrecta. Verifique los parámetros y vuelva a intentarlo.",
                StatusCodes.Status401Unauthorized => "Acceso no autorizado. Debe iniciar sesión.",
                StatusCodes.Status403Forbidden => "Acceso denegado. No tiene permisos para acceder al recurso solicitado.",
                StatusCodes.Status404NotFound => "No se encontraron datos.",
                StatusCodes.Status405MethodNotAllowed => "Método no permitido.",
                >= StatusCodes.Status406NotAcceptable => "Ha ocurrido un error, intente mas tarde.",
                _ => "Respuesta exitosa."
            };

            return message;
        }
    }
}

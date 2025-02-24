using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public string? Method { get; set; }
        public string? Message { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response
{
    public class BaseResponse<T>
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }
    }
}

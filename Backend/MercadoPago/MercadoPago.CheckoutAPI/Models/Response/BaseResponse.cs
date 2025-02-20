using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Models.Response
{
    public class BaseResponse
    {
        [JsonIgnore]
        public HttpResponseMessage? Data { get; set; }
        public object? Content { get; set; }   
        public string? Message { get; set; }
    }
}

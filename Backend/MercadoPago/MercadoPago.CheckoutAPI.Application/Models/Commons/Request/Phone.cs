using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Commons.Request
{
    public class Phone
    {
        [JsonPropertyName("area_code")]
        public string? AreaCode { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }
    }
}

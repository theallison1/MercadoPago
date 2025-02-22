using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Commons
{
    public class Identification
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons
{
    public class City
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Commons.Request
{
    public class City
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Commons.Request
{
    public class Address
    {
        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("street_name")]
        public string? StreetName { get; set; }

        [JsonPropertyName("street_number")]
        public object? StreetNumber { get; set; }
    }
}

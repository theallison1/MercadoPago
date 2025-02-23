using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Commons
{
    public class Address
    {
        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("street_name")]
        public string? StreetName { get; set; }

        [JsonPropertyName("street_number")]
        public string? StreetNumber { get; set; }
    }
}

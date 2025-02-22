using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Payments
{
    public class ItemCategoryDescriptorRoute
    {
        [JsonPropertyName("departure")]
        public string? Departure { get; set; }

        [JsonPropertyName("destination")]
        public string? Destination { get; set; }

        [JsonPropertyName("departure_date_time")]
        public string? DepartureDateTime { get; set; }

        [JsonPropertyName("arrival_date_time")]
        public string? ArrivalDateTime { get; set; }

        [JsonPropertyName("company")]
        public string? Company { get; set; }
    }
}

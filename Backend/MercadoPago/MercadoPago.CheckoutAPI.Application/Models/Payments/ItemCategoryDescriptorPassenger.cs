using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Payments
{
    public class ItemCategoryDescriptorPassenger
    {
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
    }
}

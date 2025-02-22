using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Payments
{
    public class PaymentAdditionalInfoItem
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("picture_url")]
        public string? PictureUrl { get; set; }

        [JsonPropertyName("category_id")]
        public string? CategoryId { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("unit_price")]
        public float? UnitPrice { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("event_date")]
        public string? EventDate { get; set; }

        [JsonPropertyName("warranty")]
        public bool? Warranty { get; set; }

        [JsonPropertyName("category_descriptor")]
        public ItemCategoryDescriptor? CategoryDescriptor { get; set; }
    }
}

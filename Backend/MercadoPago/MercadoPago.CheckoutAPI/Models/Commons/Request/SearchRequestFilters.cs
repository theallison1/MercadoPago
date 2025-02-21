using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Models.Commons.Request
{
    public class SearchRequestFilters
    {
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        [JsonPropertyName("offset")]
        public int? Offset { get; set; }
    }
}

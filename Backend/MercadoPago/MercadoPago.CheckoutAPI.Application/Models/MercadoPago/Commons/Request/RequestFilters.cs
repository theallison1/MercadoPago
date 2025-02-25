using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons.Request
{
    public class RequestFilters
    {
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        [JsonPropertyName("offset")]
        public int? Offset { get; set; }
    }
}

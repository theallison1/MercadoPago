using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons.Request;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.PaymentMethods.Request
{
    public class PaymentMethodsRequestFilters : RequestFilters
    {
        [JsonPropertyName("public_key")]
        public string? PublicKey { get; set; }

        [JsonPropertyName("bins")]
        public string? Bins { get; set; }

        [JsonPropertyName("marketplace")]
        public string? Marketplace { get; set; }

        [JsonPropertyName("site_id")]
        public string? SiteId { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("bin")]
        public string? Bin { get; set; }

        [JsonPropertyName("amount")]
        public string? Amount { get; set; }
    }
}

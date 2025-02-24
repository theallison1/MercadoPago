using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons.Request;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.PaymentMethods.Request
{
    public class SearchPaymentMethodsRequestFilters : SearchRequestFilters
    {
        [JsonPropertyName("public_key")]
        public string? PublicKey { get; set; }

        [JsonPropertyName("bins")]
        public string? Bins { get; set; }

        [JsonPropertyName("MarketPlace")]
        public string? Marketplace { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}

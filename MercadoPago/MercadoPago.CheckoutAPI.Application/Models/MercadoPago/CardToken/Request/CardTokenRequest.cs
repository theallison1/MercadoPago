using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.CardToken.Request
{
    public class CardTokenRequest
    {
        [JsonPropertyName("card_number")]
        public string? CardNumber { get; set; }

        [JsonPropertyName("cardholder")]
        public CardHolder? CardHolder { get; set; }

        [JsonPropertyName("security_code")]
        public string? SecurityCode { get; set; }

        [JsonPropertyName("expiration_month")]
        public string? ExpirationMonth { get; set; }

        [JsonPropertyName("expiration_year")]
        public string? ExpirationYear { get; set; }
    }
}

using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.CardToken.Response
{
    public class CardTokenResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("first_six_digits")]
        public string? FirstSixDigits { get; set; }

        [JsonPropertyName("expiration_month")]
        public int? ExpirationMonth { get; set; }

        [JsonPropertyName("expiration_year")]
        public int? ExpirationYear { get; set; }

        [JsonPropertyName("last_four_digits")]
        public string? LastFourDigits { get; set; }

        [JsonPropertyName("cardholder")]
        public CardHolder? CardHolder { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("date_created")]
        public string? DateCreated { get; set; }
        
        [JsonPropertyName("date_last_updated")]
        public string? DateLastUpdated { get; set; }

        [JsonPropertyName("date_due")]
        public string? DateDue { get; set; }

        [JsonPropertyName("luhn_validation")]
        public bool? LuhnValidation { get; set; }

        [JsonPropertyName("live_mode")]
        public bool? LiveMode { get; set; }

        [JsonPropertyName("require_esc")]
        public bool? RequireEsc { get; set; }

        [JsonPropertyName("card_number_length")]
        public int? CardNumberLength { get; set; }

        [JsonPropertyName("security_code_length")]
        public int? SecurityCodeLength { get; set; }
    }
}

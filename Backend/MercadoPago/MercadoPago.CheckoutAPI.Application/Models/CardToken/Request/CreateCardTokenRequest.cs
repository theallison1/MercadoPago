using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Application.Models.CardToken.Request
{
    public class CreateCardTokenRequest
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

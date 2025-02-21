using MercadoPago.CheckoutAPI.Models.Payments.Request;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Models.Payments
{
    public class PaymentAdditionalInfo
    {
        [JsonPropertyName("ip_address")]
        public string? IpAddress { get; set; }

        [JsonPropertyName("items")]
        public PaymentAdditionalInfoItem[]? Items { get; set; }

        [JsonPropertyName("payer")]
        public PaymentAdditionalInfoPayer? Payer { get; set; }
    }
}

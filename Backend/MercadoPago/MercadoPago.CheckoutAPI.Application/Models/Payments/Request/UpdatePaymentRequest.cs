using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Payments.Request
{
    // Reference: https://www.mercadopago.com.ar/developers/es/reference/payments/_payments_id/put

    public class UpdatePaymentRequest
    {
        [JsonPropertyName("capture")]
        public bool? Capture { get; set; }

        [JsonPropertyName("date_of_expiration")]
        public string? DateOfExpiration { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("transaction_amount")]
        public float? TransactionAmount { get; set; }
    }
}

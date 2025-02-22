using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Payments.Request
{
    // Reference: https://www.mercadopago.com.ar/developers/es/reference/payments/_payments/post

    public class CreatePaymentRequest
    {
        [JsonPropertyName("binary_mode")]
        public bool? BinaryMode { get; set; }

        [JsonPropertyName("callback_url")]
        public string? CallbackUrl { get; set; }

        [JsonPropertyName("campaign_id")]
        public string? CampaignId { get; set; }

        [JsonPropertyName("capture")]
        public bool? Capture { get; set; }

        [JsonPropertyName("transaction_amount")]
        public float? TransactionAmount { get; set; }

        [JsonPropertyName("application_fee")]
        public float? ApplicationFee { get; set; }

        [JsonPropertyName("installments")]
        public int? Installments { get; set; }

        [JsonPropertyName("differential_pricing_id")]
        public int? DifferentialPricingId { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("external_reference")]
        public string? ExternalReference { get; set; }

        [JsonPropertyName("date_of_expiration")]
        public string? DateOfExpiration { get; set; }

        [JsonPropertyName("issuer_id")]
        public string? IssuerId { get; set; }

        [JsonPropertyName("notification_url")]
        public string? NotificationUrl { get; set; }

        [JsonPropertyName("payment_method_id")]
        public string? PaymentMethodId { get; set; }

        [JsonPropertyName("statement_descriptor")]
        public string? StatementDescriptor { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonPropertyName("coupon_amount")]
        public float? CouponAmount { get; set; }

        [JsonPropertyName("coupon_code")]
        public string? CouponCode { get; set; }

        [JsonPropertyName("metadata")]
        public IDictionary<string, object>? Metadata { get; set; }

        [JsonPropertyName("payer")]
        public PaymentPayer? Payer { get; set; }

        [JsonPropertyName("additional_info")]
        public PaymentAdditionalInfo? AdditionalInfo { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Models.Payments.Request
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
        public object? Metadata { get; set; }  

        [JsonPropertyName("payer")]
        public PaymentPayer? Payer { get; set; }

        [JsonPropertyName("additional_info")]
        public PaymentAdditionalInfo? AdditionalInfo { get; set; }
    }

    public class PaymentPayer
    {
        [JsonPropertyName("entity_type")]
        public string? EntityType { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("identification")]
        public PaymentPayerIdentification? Identification { get; set; }
    }

    public class PaymentPayerIdentification
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }
    }

    public class PaymentAdditionalInfo
    {
        [JsonPropertyName("ip_address")]
        public string? IpAddress { get; set; }

        [JsonPropertyName("items")]
        public PaymentAdditionalInfoItem[]? Items { get; set; }

        [JsonPropertyName("payer")]
        public PaymentAdditionalInfoPayer? Payer { get; set; }
    }

    public class PaymentAdditionalInfoPayer
    {
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("phone")]
        public PaymentAdditionalInfoPayerPhone? Phone { get; set; }

        [JsonPropertyName("address")]
        public PaymentAdditionalInfoPayerAddress? Address { get; set; }

        [JsonPropertyName("registration_date")]
        public string? RegistrationDate { get; set; }

        [JsonPropertyName("is_prime_user")]
        public string? IsPrimeUser { get; set; }

        [JsonPropertyName("is_first_purchase_online")]
        public string? IsFirstPurchaseOnline { get; set; }

        [JsonPropertyName("last_purchase")]
        public string? LastPurchase { get; set; }

        [JsonPropertyName("authentication_type")]
        public string? AuthenticationType { get; set; }
    }

    public class PaymentAdditionalInfoPayerPhone
    {
        [JsonPropertyName("area_code")]
        public string? AreaCode { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }
    }

    public class PaymentAdditionalInfoPayerAddress
    {
        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("street_name")]
        public string? StreetName { get; set; }

        [JsonPropertyName("street_number")]
        public string? StreetNumber { get; set; }
    }

    public class PaymentAdditionalInfoItem
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("picture_url")]
        public string? PictureUrl { get; set; }

        [JsonPropertyName("category_id")]
        public string? CategoryId { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("unit_price")]
        public float? UnitPrice { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("event_date")]
        public string? EventDate { get; set; }

        [JsonPropertyName("warranty")]
        public bool? Warranty { get; set; }

        [JsonPropertyName("category_descriptor")]
        public ItemCategoryDescriptor? CategoryDescriptor { get; set; }
    }

    public class ItemCategoryDescriptor
    {
        [JsonPropertyName("passenger")]
        public ItemCategoryDescriptorPassenger? Passenger { get; set; }

        [JsonPropertyName("route")]
        public ItemCategoryDescriptorRoute? Route { get; set; }
    }

    public class ItemCategoryDescriptorPassenger
    {
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
    }

    public class ItemCategoryDescriptorRoute
    {
        [JsonPropertyName("departure")]
        public string? Departure { get; set; }

        [JsonPropertyName("destination")]
        public string? Destination { get; set; }

        [JsonPropertyName("departure_date_time")]
        public string? DepartureDateTime { get; set; }

        [JsonPropertyName("arrival_date_time")]
        public string? ArrivalDateTime { get; set; }

        [JsonPropertyName("company")]
        public string? Company { get; set; }
    }
}

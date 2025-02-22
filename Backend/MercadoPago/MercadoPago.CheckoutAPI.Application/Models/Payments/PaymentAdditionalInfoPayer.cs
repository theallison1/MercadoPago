using MercadoPago.CheckoutAPI.Application.Models.Commons;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Payments
{
    public class PaymentAdditionalInfoPayer
    {
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("phone")]
        public Phone? Phone { get; set; }

        [JsonPropertyName("address")]
        public Address? Address { get; set; }

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
}

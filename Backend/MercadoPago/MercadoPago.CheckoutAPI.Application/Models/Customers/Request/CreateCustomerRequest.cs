using MercadoPago.CheckoutAPI.Application.Models.Commons.Request;
using MercadoPago.CheckoutAPI.Application.Models.Customers;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Customers.Request
{
    // Reference: https://www.mercadopago.com.ar/developers/es/reference/customers/_customers/post

    public class CreateCustomerRequest
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("phone")]
        public Phone? Phone { get; set; }

        [JsonPropertyName("identification")]
        public Identification? Identification { get; set; }

        [JsonPropertyName("default_address")]
        public string? DefaultAddress { get; set; }

        [JsonPropertyName("address")]
        public CustomerAddress? Address { get; set; }

        [JsonPropertyName("date_registered")]
        public string? DateRegistered { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("default_card")]
        public string? DefaultCard { get; set; }
    }
}

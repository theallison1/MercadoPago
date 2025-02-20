using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Models.Customers.Request
{
    // Reference: https://www.mercadopago.com.ar/developers/es/reference/customers/_customers_search/get

    public class SearchCustomersRequestFilters
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}

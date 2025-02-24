using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons.Request;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Customers.Request
{
    // Reference: https://www.mercadopago.com.ar/developers/es/reference/customers/_customers_search/get

    public class SearchCustomersRequestFilters : SearchRequestFilters
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}

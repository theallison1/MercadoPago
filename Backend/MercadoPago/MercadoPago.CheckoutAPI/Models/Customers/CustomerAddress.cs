using MercadoPago.CheckoutAPI.Models.Commons.Request;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Models.Customers
{
    public class CustomerAddress : Address
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("city")]
        public City? City { get; set; }
    }
}

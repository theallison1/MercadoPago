using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Models.Customers.Request
{
    // Reference: https://www.mercadopago.com.ar/developers/es/reference/cards/_customers_customer_id_cards_id/put

    public class UpdateCustomerCardRequest
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}

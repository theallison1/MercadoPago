using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Models.CustomerCards.Request
{
    // Reference: https://www.mercadopago.com.ar/developers/es/reference/cards/_customers_customer_id_cards/post

    public class CreateCustomerCardRequest
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}

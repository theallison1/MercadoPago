using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Customers
{
    public class CustomerAddress : Address
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("street_number")]
        public new long? StreetNumber
        {
            get => long.TryParse(base.StreetNumber, out long number) ? number : null;
            set => base.StreetNumber = value?.ToString();
        }
    }
}

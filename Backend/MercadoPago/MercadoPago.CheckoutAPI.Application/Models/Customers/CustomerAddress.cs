using MercadoPago.CheckoutAPI.Application.Models.Commons;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Customers
{
    public class CustomerAddress : Address
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("street_number")]
        public new Int64? StreetNumber
        {
            get => Int64.TryParse(base.StreetNumber, out Int64 number) ? number : null;
            set => base.StreetNumber = value?.ToString();
        }
    }
}

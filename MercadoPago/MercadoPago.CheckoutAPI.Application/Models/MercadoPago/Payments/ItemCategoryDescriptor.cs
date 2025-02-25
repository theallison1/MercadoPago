using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Payments.Request;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Payments
{
    public class ItemCategoryDescriptor
    {
        [JsonPropertyName("passenger")]
        public ItemCategoryDescriptorPassenger? Passenger { get; set; }

        [JsonPropertyName("route")]
        public ItemCategoryDescriptorRoute? Route { get; set; }
    }
}

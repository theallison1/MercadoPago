using MercadoPago.CheckoutAPI.Models.Payments.Request;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Models.Payments
{
    public class ItemCategoryDescriptor
    {
        [JsonPropertyName("passenger")]
        public ItemCategoryDescriptorPassenger? Passenger { get; set; }

        [JsonPropertyName("route")]
        public ItemCategoryDescriptorRoute? Route { get; set; }
    }
}

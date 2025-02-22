using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Users.Request
{
    public class CreateTestUserRequest
    {
        [JsonPropertyName("site_id")]
        public string? SiteId { get; set; }


        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}

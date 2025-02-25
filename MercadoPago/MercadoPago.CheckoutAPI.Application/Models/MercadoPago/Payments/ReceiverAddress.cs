using MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Payments
{
    public class ReceiverAddress : Address
    {
        [JsonPropertyName("state_name")]
        public string? StateName { get; set; }

        [JsonPropertyName("city_name")]
        public string? CityName { get; set; }

        [JsonPropertyName("street_number")]
        public new long? StreetNumber
        {
            get => long.TryParse(base.StreetNumber, out long number) ? number : null;
            set => base.StreetNumber = value?.ToString();
        }

        [JsonPropertyName("floor")]
        public string? Floor { get; set; }

        [JsonPropertyName("apartment")]
        public string? Apartment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Commons
{
    public class CardHolder
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("identification")]
        public Identification? Identification { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Application.Models.MercadoPago.Payments
{
    public class PaymentAdditionalInfoShipment
    {
        [JsonPropertyName("receiver_address")]
        public ReceiverAddress? ReceiverAddress { get; set; }

        [JsonPropertyName("width")]
        public int? Width { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("express_shipment")]
        public string? ExpressShipment { get; set; }

        [JsonPropertyName("pick_up_on_seller")]
        public string? PickUpOnSeller { get; set; }
    }
}

﻿using MercadoPago.CheckoutAPI.Application.Models.Commons;
using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Customers.Request
{
    // Reference: https://www.mercadopago.com.ar/developers/es/reference/customers/_customers_id/put

    public class UpdateCustomerRequest
    {
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("phone")]
        public Phone? Phone { get; set; }

        [JsonPropertyName("identification")]
        public Identification? Identification { get; set; }

        [JsonPropertyName("default_address")]
        public string? DefaultAddress { get; set; }

        [JsonPropertyName("address")]
        public CustomerAddress? Address { get; set; }

        [JsonPropertyName("date_registered")]
        public string? DateRegistered { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("default_card")]
        public string? DefaultCard { get; set; }
    }
}

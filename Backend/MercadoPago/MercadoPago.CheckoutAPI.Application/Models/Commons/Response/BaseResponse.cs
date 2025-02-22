﻿using System.Text.Json.Serialization;

namespace MercadoPago.CheckoutAPI.Application.Models.Commons.Response
{
    public class BaseResponse
    {
        [JsonIgnore]
        public HttpResponseMessage? Data { get; set; }
        public object? Content { get; set; }
        public int? StatusCode { get; set; }
        public string? Method { get; set; }
        public string? Message { get; set; }
    }
}

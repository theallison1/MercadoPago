using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Application.Serialization
{
    public interface ISerializer
    {
        HttpRequestMessage AddJsonBodyToContent<T>(HttpRequestMessage request, T bodyRequest);
        Task<object?> DeserializeJsonAsync(HttpResponseMessage response);
        public string SetQueryParams<T>(T filters);
    }
}

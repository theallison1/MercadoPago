using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Application.Dtos.Users.Request
{
    public class TokenRequestDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

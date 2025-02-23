using System.Collections;

namespace MercadoPago.CheckoutAPI.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public Role? Role { get; set; }
    }
}

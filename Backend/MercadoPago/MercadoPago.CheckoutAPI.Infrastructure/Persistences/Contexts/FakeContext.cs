using MercadoPago.CheckoutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Infrastructure.Persistences.Contexts
{
    public class FakeContext
    {
        private IEnumerable<Users> _users { get; set; }

        public FakeContext() 
        { 
            _users = new List<Users>() 
            {
                new Users() 
                {
                    // ADMIN
                    UserName = "Admin",
                    Password = "1234",
                    Email = "test@admin.com.ar",
                    Rol = "administrator"
                },
                new Users()
                {
                    // CUSTOMER
                    UserName = "Customer",
                    Password = "1234",
                    Email = "test@customer.com.ar",
                    Rol = "customer"
                }
            };
        }

        public IEnumerable<Users> Users { get { return _users; } }
    }
}

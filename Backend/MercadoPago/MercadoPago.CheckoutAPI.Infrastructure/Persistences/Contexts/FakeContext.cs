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
        private IEnumerable<Role> _roles { get; set; } 
        private IEnumerable<User> _users { get; set; }

        public FakeContext() 
        {
            _roles = new List<Role>()
            {
                new Role()
                {
                    RoleId = 1,
                    Description = "administrator"
                },
                new Role()
                {
                    RoleId = 2,
                    Description = "supervisor"
                },
                new Role()
                {
                    RoleId = 3,
                    Description = "customer"
                },
            };

            _users = new List<User>()
            {
                new User()
                {
                    // ADMIN
                    UserId = 1,
                    UserName = "Admin",
                    Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", // 1234
                    Email = "test@admin.com.ar",
                    Role = _roles.FirstOrDefault(r => r.RoleId == 1)
                },
                new User()
                {
                    // CUSTOMER
                    UserId = 2,
                    UserName = "Customer",
                    Password = "fe2592b42a727e977f055947385b709cc82b16b9a87f88c6abf3900d65d0cdc3", // 4321
                    Email = "test@customer.com.ar",
                    Role = _roles.FirstOrDefault(r => r.RoleId == 3)
                }
            };
        }

        public IEnumerable<Role> Roles { get { return _roles; } }
        public IEnumerable<User> Users { get { return _users; } }
    }
}

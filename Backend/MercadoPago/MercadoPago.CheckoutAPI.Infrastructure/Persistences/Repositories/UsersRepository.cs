using MercadoPago.CheckoutAPI.Domain.Entities;
using MercadoPago.CheckoutAPI.Infrastructure.Persistences.Contexts;
using MercadoPago.CheckoutAPI.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Infrastructure.Persistences.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FakeContext _context;

        public UsersRepository(FakeContext context)
        {
            _context = context;
        }

        public async Task<Users?> GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email.Equals(email));
            
            await Task.CompletedTask;

            return user;
        }
    }
}

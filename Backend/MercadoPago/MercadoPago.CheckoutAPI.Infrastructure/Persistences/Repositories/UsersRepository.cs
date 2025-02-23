using MercadoPago.CheckoutAPI.Domain.Entities;
using MercadoPago.CheckoutAPI.Infrastructure.Persistences.Contexts;
using MercadoPago.CheckoutAPI.Infrastructure.Persistences.Interfaces;

namespace MercadoPago.CheckoutAPI.Infrastructure.Persistences.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FakeContext _context;

        public UsersRepository(FakeContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email.Equals(email));
            
            await Task.CompletedTask;

            return user;
        }
    }
}

using MercadoPago.CheckoutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Infrastructure.Persistences.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> GetUserByEmail(string email);
    }
}

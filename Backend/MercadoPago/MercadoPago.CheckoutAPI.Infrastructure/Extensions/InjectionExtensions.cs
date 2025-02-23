using MercadoPago.CheckoutAPI.Infrastructure.Persistences.Contexts;
using MercadoPago.CheckoutAPI.Infrastructure.Persistences.Interfaces;
using MercadoPago.CheckoutAPI.Infrastructure.Persistences.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoPago.CheckoutAPI.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<FakeContext>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}

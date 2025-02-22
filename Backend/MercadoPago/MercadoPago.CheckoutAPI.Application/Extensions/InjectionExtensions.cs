using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Serialization;
using MercadoPago.CheckoutAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoPago.CheckoutAPI.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandlerService, RequestHandlerService>();
            services.AddScoped<ICustomerCardsService, CustomerCardsService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IPaymentMethodsService, PaymentMethodsService>();
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ISerializer, Serializer>();

            return services;
        }
    }
}

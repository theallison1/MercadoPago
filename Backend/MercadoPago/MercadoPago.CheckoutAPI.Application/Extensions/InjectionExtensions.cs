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
            services.AddScoped<IHttpClientManagerApplication, HttpClientManagerApplication>();
            services.AddScoped<ICustomerCardsApplication, CustomerCardsApplication>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<IPaymentMethodsApplication, PaymentMethodsApplication>();
            services.AddScoped<IPaymentsApplication, PaymentsApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<ICardTokensApplication, CardTokensApplication>();
            services.AddScoped<ISerializer, Serializer>();

            return services;
        }
    }
}

using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Services;

namespace MercadoPago.CheckoutAPI.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionExtensions(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandlerService, RequestHandlerService>();
            services.AddScoped<ICustomerCardsService, CustomerCardsService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IPaymentMethodsService, PaymentMethodsService>();
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IUsersService, UsersService>();

            return services;
        }
    }
}

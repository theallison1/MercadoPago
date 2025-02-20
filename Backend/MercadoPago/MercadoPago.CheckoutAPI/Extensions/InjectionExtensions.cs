using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Services;

namespace MercadoPago.CheckoutAPI.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionExtensions(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandlerService, RequestHandlerService>();
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IPaymentMethodsService, PaymentMethodsService>();

            return services;
        }
    }
}

using MercadoPago.CheckoutAPI.Application.Extensions;
using MercadoPago.CheckoutAPI.Application.Settings;
using MercadoPago.CheckoutAPI.Extensions;
using MercadoPago.CheckoutAPI.Infrastructure.Extensions;
using MercadoPago.CheckoutAPI.Middlewares;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Cargar configuración
var configuration = builder.Configuration;
var cors = "CORS";

// Configurar HttpClient para MercadoPago
builder.Services.AddHttpClient("MercadoPagoHttpClient", client =>
{
    var baseUrl = configuration["MercadoPago:UrlBase"];
    var accessToken = configuration["MercadoPago:AccessToken"];

    if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrWhiteSpace(accessToken))
    {
        throw new InvalidOperationException("MercadoPago:UrlBase o MercadoPago:AccessToken no están configurados.");
    }

    client.BaseAddress = new Uri(baseUrl);
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
});

// Configurar servicios de infraestructura y aplicación
builder.Services.AddInjectionInfrastructure();
builder.Services.AddInjectionApplication();

// Configurar autenticación JWT
builder.Services.AddAuthentication(configuration);

// Configurar autorización
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationHandler>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(cors, policy =>
    {
        policy.WithOrigins("*");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

// Configurar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configurar opciones de MercadoPago y JWT
builder.Services.Configure<MercadoPagoSettings>(builder.Configuration.GetSection("MercadoPago"));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

// Construir la aplicación
var app = builder.Build();

// Configurar el pipeline de la aplicación
app.UseCors(cors);
app.UseHttpsRedirection();
app.UseAuthentication(); // Asegúrate de que esto esté antes de UseAuthorization
app.UseAuthorization();
app.MapControllers();

// Ejecutar la aplicación
app.Run();

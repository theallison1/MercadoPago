using MercadoPago.CheckoutAPI.Extensions;
using MercadoPago.CheckoutAPI.Settings;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

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

builder.Services.AddInjectionExtensions();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MercadoPagoSettings>(builder.Configuration.GetSection("MercadoPago"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

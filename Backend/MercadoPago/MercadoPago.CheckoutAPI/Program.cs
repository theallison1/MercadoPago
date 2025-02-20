using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
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

builder.Services.AddScoped<IRequestHandlerService, RequestHandlerService>();
builder.Services.AddScoped<IPaymentsService, PaymentsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace MercadoPago.CheckoutAPI.Application.Settings
{
    public class JwtSettings
    {
        public string? Issuer { get; set; }
        public string? SecretKey { get; set; }
        public double Expires { get; set; }
    }
}

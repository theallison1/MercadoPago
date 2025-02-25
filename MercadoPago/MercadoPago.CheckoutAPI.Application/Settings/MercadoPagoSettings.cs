namespace MercadoPago.CheckoutAPI.Application.Settings
{
    public class MercadoPagoSettings
    {
        public string? UrlBase { get; set; }
        public string? AccessToken { get; set; }
        public string? PublicKey { get; set; }
        public int? MaxRetriesHTTP { get; set; }
        public int? RetryDelayMilliseconds { get; set; }
    }
}

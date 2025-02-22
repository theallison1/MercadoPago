using System.Net.Http.Headers;
using System.Text;

namespace MercadoPago.CheckoutAPI.Application.Helpers
{
    public static class RequestHelper
    {
        public const string X_IDEMPOTENCY_KEY = "X-Idempotency-Key";

        public static HttpRequestHeaders AddXIdempotencyKey(this HttpRequestHeaders headers)
        {
            headers.Add(X_IDEMPOTENCY_KEY, Guid.NewGuid().ToString());

            return headers;
        }

        public static async Task<HttpRequestMessage> CloneAsync(this HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Content = request.Content is not null ? await request.Content.CloneAsync().ConfigureAwait(false) : null,
                Version = request.Version
            };

            foreach (var header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }

        private static async Task<HttpContent> CloneAsync(this HttpContent content)
        {
            if (content is null)
                return null!;

            var memoryStream = new MemoryStream();
            await content.CopyToAsync(memoryStream).ConfigureAwait(false);
            memoryStream.Position = 0;

            HttpContent clone = content switch
            {
                StringContent => new StringContent(await content.ReadAsStringAsync().ConfigureAwait(false), Encoding.UTF8, "application/json"),
                ByteArrayContent => new ByteArrayContent(await content.ReadAsByteArrayAsync().ConfigureAwait(false)),
                _ => new StreamContent(memoryStream)
            };

            foreach (var header in content.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }
    }
}

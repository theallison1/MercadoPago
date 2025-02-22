using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Serialization;
using MercadoPago.CheckoutAPI.Application.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class HttpClientManagerApplication : IHttpClientManagerApplication
    {
        private readonly HttpClient _httpClient;
        private readonly ISerializer _serializer;
        private readonly ILogger<HttpClientManagerApplication> _logger;
        private readonly int _maxRetries;
        private readonly int _retryDelayMilliseconds;

        public HttpClientManagerApplication(IHttpClientFactory httpClientFactory, ISerializer serializer, ILogger<HttpClientManagerApplication> logger, IOptions<MercadoPagoSettings> options)
        {
            _httpClient = httpClientFactory.CreateClient("MercadoPagoHttpClient");
            _serializer = serializer;
            _logger = logger;
            _maxRetries = Convert.ToInt32(options.Value.MaxRetriesHTTP);
            _retryDelayMilliseconds = Convert.ToInt32(options.Value.RetryDelayMilliseconds);
        }

        public async Task<BaseResponse> SendAsync(HttpRequestMessage request)
        {
            BaseResponse? response = new BaseResponse();

            try
            {
                _logger.LogInformation("{TimeStamp} IN Request: {BaseAddress}{RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _httpClient.BaseAddress, request.RequestUri);
                response.Data = await _httpClient.SendAsync(request);
                response.Content = await _serializer.DeserializeJsonAsync(response.Data);
                _logger.LogInformation("{TimeStamp} OUT Request: {RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), request.RequestUri);

                if (response.Data.IsSuccessStatusCode)
                {
                    return response;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("{TimeStamp} ERROR: {Exception}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex);
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse> SendWithRetryAsync(HttpRequestMessage request)
        {
            int attempts = 0;
            BaseResponse? response = new BaseResponse();

            while (attempts < _maxRetries)
            {
                attempts++;
                try
                {
                    HttpRequestMessage attemptRequest = await CloneRequestAsync(request);
                    _logger.LogInformation("{TimeStamp} IN Request: (Intento Nro {Attempts}): {BaseAddress}{RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, _httpClient.BaseAddress, attemptRequest.RequestUri);
                    response.Data = await _httpClient.SendAsync(attemptRequest);
                    response.Content = await _serializer.DeserializeJsonAsync(response.Data);
                    _logger.LogInformation("{TimeStamp} OUT Request: (Intento Nro {Attempts}): {RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, attemptRequest.RequestUri);

                    if (response.Data.IsSuccessStatusCode)
                    {
                        return response;
                    }

                    if (response.Data.StatusCode == HttpStatusCode.RequestTimeout || (int)response.Data.StatusCode >= 500)
                    {
                        await Task.Delay(_retryDelayMilliseconds);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("{TimeStamp} (Intento Nro {Attempts}) ERROR: {Exception}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, ex);
                    if (attempts < _maxRetries)
                    {
                        await Task.Delay(_retryDelayMilliseconds);
                    }
                    else
                    {
                        response.Message = ex.Message;
                    }
                }
            }

            return response;
        }

        public HttpRequestHeaders AddXIdempotencyKey(HttpRequestHeaders headers)
        {
            string X_IDEMPOTENCY_KEY = "X-Idempotency-Key";

            headers.Add(X_IDEMPOTENCY_KEY, Guid.NewGuid().ToString());

            return headers;
        }

        public void RemoveVersionUrlBase()
        {
            _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress.ToString().Replace("/v1", ""));
        }

        private static async Task<HttpRequestMessage> CloneRequestAsync(HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Content = request.Content is not null ? await CloneContentAsync(request.Content).ConfigureAwait(false) : null,
                Version = request.Version
            };

            foreach (var header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }

        private static async Task<HttpContent> CloneContentAsync(HttpContent content)
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

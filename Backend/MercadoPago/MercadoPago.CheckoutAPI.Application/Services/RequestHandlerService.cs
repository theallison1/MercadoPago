using MercadoPago.CheckoutAPI.Application.Helpers;
using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Serialization;
using MercadoPago.CheckoutAPI.Application.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class RequestHandlerService : IRequestHandlerService
    {
        private readonly HttpClient _httpClient;
        private readonly ISerializer _serializer;
        private readonly ILogger<RequestHandlerService> _logger;
        private readonly int _maxRetries;
        private readonly int _retryDelayMilliseconds;

        public RequestHandlerService(IHttpClientFactory httpClientFactory, ISerializer serializer, ILogger<RequestHandlerService> logger, IOptions<MercadoPagoSettings> options)
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
                _logger.LogInformation("{TimeStamp} Inicio request: {BaseAddress}{RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _httpClient.BaseAddress, request.RequestUri);
                response.Data = await _httpClient.SendAsync(request);
                response.Content = await _serializer.DeserializeJsonAsync(response.Data);
                _logger.LogInformation("{TimeStamp} Fin request: {RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), request.RequestUri);

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
                    HttpRequestMessage attemptRequest = await request.CloneAsync();
                    _logger.LogInformation("{TimeStamp} Inicio request: (Intento Nro {Attempts}): {BaseAddress}{RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, _httpClient.BaseAddress, attemptRequest.RequestUri);
                    response.Data = await _httpClient.SendAsync(attemptRequest);
                    response.Content = await _serializer.DeserializeJsonAsync(response.Data);
                    _logger.LogInformation("{TimeStamp} Fin request: (Intento Nro {Attempts}): {RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, attemptRequest.RequestUri);

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

        public void RemoveVersionUrlBase()
        {
            _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress.ToString().Replace("/v1", ""));
        }
    }
}

using MercadoPago.CheckoutAPI.Helpers;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Response;
using System.Net;
using System.Text.Json;

namespace MercadoPago.CheckoutAPI.Services
{
    public class RequestHandlerService : IRequestHandlerService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RequestHandlerService> _logger;

        public RequestHandlerService(IHttpClientFactory httpClientFactory, ILogger<RequestHandlerService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("MercadoPagoHttpClient");
            _logger = logger;
        }

        public async Task<BaseResponse> SendAsync(HttpRequestMessage request)
        {
            BaseResponse? response = new BaseResponse();

            try
            {
                _logger.LogInformation("{TimeStamp} Inicio request: {BaseAddress}{RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _httpClient.BaseAddress, request.RequestUri);
                response.Data = await _httpClient.SendAsync(request);
                response.Content = await response.Data.GetContentAsync(_logger);
                _logger.LogInformation("{TimeStamp} Fin request: {RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), request.RequestUri);

                response.ValidateStatusCodeMessage();
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

        public async Task<BaseResponse> SendWithRetryAsync(HttpRequestMessage request, int maxRetries = 3, int delayMilliseconds = 1000)
        {
            int attempts = 0;
            BaseResponse? response = new BaseResponse();

            while (attempts < maxRetries)
            {
                attempts++;
                try
                {
                    _logger.LogInformation("{TimeStamp} (Intento Nro {Attempts}): {BaseAddress}{RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, _httpClient.BaseAddress, request.RequestUri);
                    response.Data = await _httpClient.SendAsync(request);
                    response.Content = await response.Data.GetContentAsync(_logger);
                    _logger.LogInformation("{TimeStamp} (Intento Nro {Attempts}): {RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, request.RequestUri);

                    response.ValidateStatusCodeMessage();
                    if (response.Data.IsSuccessStatusCode)
                    {
                        return response;
                    }

                    if (response.Data.StatusCode == HttpStatusCode.RequestTimeout || (int)response.Data.StatusCode >= 500)
                    {
                        await Task.Delay(delayMilliseconds); 
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    if (attempts < maxRetries)
                    {
                        await Task.Delay(delayMilliseconds);
                    }
                    else
                    {
                        _logger.LogError("{TimeStamp} (Intento Nro {Attempts}) ERROR: {Exception}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, ex);
                        response.Message = ex.Message;
                    }
                }
            }

            return response;
        }
    }
}

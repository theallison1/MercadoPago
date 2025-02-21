using MercadoPago.CheckoutAPI.HttpUtilities;
using MercadoPago.CheckoutAPI.Interfaces;
using MercadoPago.CheckoutAPI.Models.Commons.Response;
using System.Net;

namespace MercadoPago.CheckoutAPI.Services
{
    public class RequestHandlerService : IRequestHandlerService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RequestHandlerService> _logger;
        private readonly int _maxRetries;
        private readonly int _retryDelayMilliseconds;

        public RequestHandlerService(IHttpClientFactory httpClientFactory, ILogger<RequestHandlerService> logger, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("MercadoPagoHttpClient");
            _logger = logger;
            _maxRetries = Convert.ToInt32(configuration["MercadoPago:MaxRetriesHTTP"]);
            _retryDelayMilliseconds = Convert.ToInt32(configuration["MercadoPago:RetryDelayMilliseconds"]);
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
                    _logger.LogInformation("{TimeStamp} (Intento Nro {Attempts}): {BaseAddress}{RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, _httpClient.BaseAddress, request.RequestUri);
                    response.Data = await _httpClient.SendAsync(attemptRequest);
                    response.Content = await response.Data.GetContentAsync(_logger);
                    _logger.LogInformation("{TimeStamp} (Intento Nro {Attempts}): {RequestUri}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), attempts, request.RequestUri);

                    response.ValidateStatusCodeMessage();
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
    }
}

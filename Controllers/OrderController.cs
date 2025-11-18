using Microsoft.AspNetCore.Mvc;
using NotARealCompanyWithViews.Models;
using NotARealCompanyWithViews.Services;
using System.Diagnostics;
using System.Net;

namespace NotARealCompanyWithViews.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private static HttpClient? _httpClient = null;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;

            if (_httpClient == null)
            {
                HttpClientHandler handler = new()
                {
                    AutomaticDecompression = DecompressionMethods.All
                };

                _httpClient = new HttpClient(handler);
            }

            // Should be replaced in constants
            _httpClient.BaseAddress = new Uri(Constants.Constants.API_BASE_URL);
        }

        [HttpGet]
        [Route("aggregate")]
        public async Task<IEnumerable<OrderDTO>> GetOrderInformation(IEnumerable<OrderInputData> ordersFromInput)
        {
            IEnumerable<OrderDTO> orders = [];
            IEnumerable<OrderInputData> ordersFromInputFinal = [];

            try
            {
                _logger.LogInformation("GetOrderInformation called at: {time}", DateTimeOffset.Now);

                // N.B. This logic is just for demonstration purposes
                // After changing the constant to false, this block will attempt to call the API (provided URL is valid)
                if (Constants.Constants.IS_LOCAL)
                {
                    ordersFromInputFinal = await _orderService.ReadSampleFileAsync(Constants.Constants.LOCAL_JSON_PATH);
                }
                else if (ordersFromInput != null && ordersFromInput.Any())
                {
                    ordersFromInputFinal = ordersFromInput;
                }
                else
                {
                    // Will not work with current URL
                    ordersFromInputFinal = await _orderService.GetOrdersFromApiAsync(Constants.Constants.API_REQUEST_URL, _httpClient);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging GetOrderInformation call.");
                Console.WriteLine($"An error occurred while logging: {ex.Message}");
            }
            finally
            {
                _logger.LogInformation("GetOrderInformation completed at: {time}", DateTimeOffset.Now);
            }

            orders = await _orderService.MapOrderDTOsAsync(ordersFromInputFinal);
            return await Task.Run(() => orders);
        }

        public async Task<IActionResult> Index()
        {
            var orderData = await GetOrderInformation([]);
            return await Task.Run(() => View(orderData));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return await Task.Run(() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }));
        }
    }
}

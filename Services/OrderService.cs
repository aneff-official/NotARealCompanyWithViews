using NotARealCompanyWithViews.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NotARealCompanyWithViews.Services
{
    public class OrderService : IOrderService
    {
        public JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            AllowTrailingCommas = true,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip,
            DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower,
            IncludeFields = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            ReadCommentHandling = JsonCommentHandling.Skip,
            PropertyNameCaseInsensitive = false,
            PreferredObjectCreationHandling = JsonObjectCreationHandling.Replace,
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower) } // underscore
        };

        public async Task SerializeToJsonAsync(IEnumerable<OrderDTO> orders)
        {
            await using FileStream createStream = File.Create(Constants.Constants.LOCAL_JSON_PATH_OUTPUT);
            await JsonSerializer.SerializeAsync(createStream, orders, SerializerOptions);
        }

        public async Task<IEnumerable<OrderInputData>> ReadSampleFileAsync(string jsonPath)
        {
            IEnumerable<OrderInputData> orders;
            var json = await File.ReadAllTextAsync(jsonPath, Encoding.Latin1);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            try
            {
                stream.Position = 0;
                stream.Seek(0, SeekOrigin.Begin);
                orders = await JsonSerializer.DeserializeAsync<IEnumerable<OrderInputData>>(stream, SerializerOptions) ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting stream position: {ex.Message}");
                return [];
            }

            if (orders == null) return [];
            return orders;
        }

        public async Task<IEnumerable<OrderInputData>> GetOrdersFromApiAsync(string url, HttpClient client)
        {
            IEnumerable<OrderInputData> orders;
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            orders = await JsonSerializer.DeserializeAsync<IEnumerable<OrderInputData>>(responseStream, SerializerOptions) ?? [];

            if (orders == null) return [];
            return orders;
        }

        public string BuildAddressString(AddressInfo? address)
        {
            if (address == null) return "Error: Missing Address";

            var strBuilder = new StringBuilder();

            strBuilder.AppendLine($"Name: {address.Name ?? "Missing"}");
            strBuilder.AppendLine($"Address: {address.Address ?? "Missing"}");
            strBuilder.AppendLine($"City: {address.City ?? "Missing"}");
            strBuilder.AppendLine($"State: {address.State ?? "Missing"}");
            strBuilder.AppendLine($"Country: {address.Country ?? "Missing"}");
            strBuilder.AppendLine($"Lat: {address.Lat ?? "Missing"}");
            strBuilder.AppendLine($"Lon: {address.Lon ?? "Missing"}");

            string? result = strBuilder.ToString() ?? "Unknown Error";
            return result;
        }

        public async Task<IEnumerable<OrderDTO>> MapOrderDTOsAsync(IEnumerable<OrderInputData> orderInputData)
        {
            var orderDTOs = new List<OrderDTO>();

            foreach (var order in orderInputData)
            {
                // Handle Order details that are shared then more specific ones
                var id = order.Id ?? "Error: Missing Order Id";
                var customerId = order.Customer?.Id ?? 0;
                var customerEmail = order.Customer?.Email ?? "";
                var customerForenames = order.Customer?.First ?? "";
                var customerSurname = order.Customer?.Last ?? "";
                var customerAddress = BuildAddressString(order.BillingAddress);
                var shippingAddress = BuildAddressString(order.ShippingAddress);

                // Handle empty Items array
                if (order.Items == null || !order.Items.Any())
                {
                    var errorMsg = string.Format("Error: Customer: {0} has made an order: {1} with no items.", customerId, id);
                    throw new Exception(errorMsg);
                }

                foreach (var item in order.Items)
                {
                    orderDTOs.Add(new OrderDTO
                    {
                        Id = id,
                        CustomerId = customerId,
                        CustomerEmail = customerEmail,
                        CustomerForenames = customerForenames,
                        CustomerSurname = customerSurname,
                        CustomerAddress = customerAddress,
                        ProductName = item.Title ?? "Error: Missing Product Name",
                        ProductSku = item.Sku ?? "Error: Missing Product SKU",
                        ProductQuantity = item.Quantity ?? 0,
                        ProductPrice = item.Price ?? 0.0m,
                        ShippingAddress = shippingAddress,
                        PurchasedOn = order.CompletedAt,
                        PurchasedOnDate = order.CompletedAt.HasValue ? DateOnly.FromDateTime(order.CompletedAt.Value) : null
                    });
                }

            }

            return await Task.FromResult(orderDTOs);
        }
    }
}

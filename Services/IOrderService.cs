using NotARealCompanyWithViews.Models;

namespace NotARealCompanyWithViews.Services
{
    public interface IOrderService
    {
        string BuildAddressString(AddressInfo? address);
        Task<IEnumerable<OrderInputData>> ReadSampleFileAsync(string jsonPath);
        Task<IEnumerable<OrderInputData>> GetOrdersFromApiAsync(string url, HttpClient client);
        Task<IEnumerable<OrderDTO>> MapOrderDTOsAsync(IEnumerable<OrderInputData> orderInputData);
    }
}

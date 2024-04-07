using NotYourAverageBicepShoppingApp.UIApp.Models;
using System.Text.Json;

namespace NotYourAverageBicepShoppingApp.UIApp.APIClient
{
    public class OrdersClient : IOrdersClient
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public OrdersClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;


        }
        public async Task<Order> PostOrders(Order order)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("OrdersApiClient");
                string jsonOrder = JsonSerializer.Serialize(order, typeof(Order));
                StringContent content = new StringContent(jsonOrder, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/api/Orders", content);
                var responseBody = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Order>(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

        }
    }
}

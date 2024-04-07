using NotYourAverageBicepShoppingApp.UIApp.Models;
using System.Text.Json;

namespace NotYourAverageBicepShoppingApp.UIApp.APIClient
{
    public class ProductsClient : IProductsClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Product>?> GetAllProductsAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("ProductsApiClient");
                var productsStreamTask = await client.GetStreamAsync("/api/Products");
                return await JsonSerializer.DeserializeAsync<List<Product>>(productsStreamTask);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<Product?> GetProductByIdAsync(string id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("ProductsApiClient");
                var productByIdStreamTask = await client.GetStreamAsync($"/api/Products/{id}");
                return await JsonSerializer.DeserializeAsync<Product>(productByIdStreamTask);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}

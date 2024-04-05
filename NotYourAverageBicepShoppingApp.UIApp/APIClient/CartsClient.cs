
using Azure;
using NotYourAverageBicepShoppingApp.UIApp.Models;
using System.Text;
using System.Text.Json;

namespace NotYourAverageBicepShoppingApp.UIApp.APIClient
{
    public class CartsClient : ICartsClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartsClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;


        }

        public async Task<Cart?> PostNewCartAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("CartsApiClient");
                var content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/api/Carts", content);
                var responseBody = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Cart>(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<CartDetailsDTO?> GetAllCartItemsForCartAsync(int cartId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("CartsApiClient");
                var cartsStreamTask = await client.GetStreamAsync($"/api/Carts/{cartId}");
                return await JsonSerializer.DeserializeAsync<CartDetailsDTO>(cartsStreamTask);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

        }


        public async Task<CartItem?> PutAddProductToCartAsync(int cartId, int productId)
        {
            try
            {
                var cartClient = _httpClientFactory.CreateClient("CartsApiClient");
                var productClient = _httpClientFactory.CreateClient("ProductsApiClient");
                var productsStreamTask = await productClient.GetStreamAsync($"/api/Products/{productId}");
                var productJsonDeserialize = await JsonSerializer.DeserializeAsync<Product>(productsStreamTask);
                string productJson = JsonSerializer.Serialize(productJsonDeserialize, typeof(Product));
                StringContent content = new StringContent(productJson, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage putResponse = await cartClient.PutAsync($"/api/Carts/{cartId}/add-product/{productId}", content);
                var putResponseBody = await putResponse.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<CartItem>(putResponseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<List<CartItem>?> PutDeleteProductFromCartAsync(int cartId, int productId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("CartsApiClient");
                var cartsStreamTask = await client.GetStreamAsync($"/api/Carts/{cartId}");
                var cartJsonDeserialize = await JsonSerializer.DeserializeAsync<Cart>(cartsStreamTask);
                string cartJson = JsonSerializer.Serialize(cartJsonDeserialize, typeof(Cart));
                StringContent content = new StringContent(cartJson, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage putResponse = await client.PutAsync($"/api/Carts/{cartId}/remove-product/{productId}", content);
                var putResponseBody = await putResponse.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<CartItem>>(putResponseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<List<CartItem>?> PutDeleteAllProductsFromCartAsync(int cartId)
        {
            try
            {
                var cartClient = _httpClientFactory.CreateClient("CartsApiClient");
                var cartsStreamTask = await cartClient.GetStreamAsync($"/api/Carts/{cartId}");
                var cartJsonDeserialize = await JsonSerializer.DeserializeAsync<Cart>(cartsStreamTask);
                string cartJson = JsonSerializer.Serialize(cartJsonDeserialize, typeof(Cart));
                StringContent content = new StringContent(cartJson, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage putResponse = await cartClient.PutAsync($"/api/Carts/clear-items/{cartId}", content);
                var putResponseBody = await putResponse.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<CartItem>>(putResponseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }


        }
    }
}

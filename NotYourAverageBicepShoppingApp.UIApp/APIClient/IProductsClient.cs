using NotYourAverageBicepShoppingApp.UIApp.Models;

namespace NotYourAverageBicepShoppingApp.UIApp.APIClient
{
    public interface IProductsClient
    {
        Task<List<Product>?> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(string id);
    }
}

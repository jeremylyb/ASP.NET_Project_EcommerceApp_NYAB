using NotYourAverageBicepShoppingApp.UIApp.Models;

namespace NotYourAverageBicepShoppingApp.UIApp.APIClient
{
    public interface IOrdersClient
    {
        Task<Order> PostOrders(Order order);
    }
}

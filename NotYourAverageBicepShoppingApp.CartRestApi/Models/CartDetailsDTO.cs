
using System.Text.Json.Serialization;

namespace NotYourAverageBicepShoppingApp.CartRestApi.Models;

public class CartDetailsDTO
    {
    [JsonPropertyName("cart")]
    public Cart Cart { get; set; }

    [JsonPropertyName("cartItemsWithProducts")]
    public List<CartItemWithProduct> CartItemsWithProducts { get; set; }
}


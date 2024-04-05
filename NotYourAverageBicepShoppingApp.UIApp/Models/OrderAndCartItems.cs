using System.Text.Json.Serialization;

namespace NotYourAverageBicepShoppingApp.UIApp.Models;

internal class OrderAndCartItems
{
    [JsonPropertyName("order")]
    public Order Order { get; set; }

    [JsonPropertyName("cartDetailsDTO")]
    public CartDetailsDTO? CartDetailsDTO { get; internal set; }
}

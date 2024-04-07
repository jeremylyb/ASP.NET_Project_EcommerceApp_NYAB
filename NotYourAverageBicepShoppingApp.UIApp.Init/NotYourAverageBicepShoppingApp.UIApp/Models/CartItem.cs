using System.Text.Json.Serialization;

namespace NotYourAverageBicepShoppingApp.UIApp.Models;

public partial class CartItem
{
    [JsonPropertyName("cartItemId")]
    public int CartItemId { get; set; }

    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("fkCartId")]
    public int FkCartId { get; set; }

    [JsonIgnore]
    public virtual Cart? FkCart { get; set; } = null!;
}

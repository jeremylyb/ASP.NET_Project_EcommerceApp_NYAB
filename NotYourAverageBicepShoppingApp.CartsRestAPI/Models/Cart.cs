using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NotYourAverageBicepShoppingApp.CartsRestAPI.Models;

public partial class Cart
{
    [JsonPropertyName("cartId")]
    public int CartId { get; set; }

    [JsonPropertyName("cartPrice")]
    public decimal? CartPrice { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}

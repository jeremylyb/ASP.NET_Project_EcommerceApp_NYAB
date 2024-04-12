using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NotYourAverageBicepShoppingApp.UIApp.Models;

/// <summary>
/// Represents a product.
/// </summary>
public partial class Product
{
    /// <summary>
    /// Gets or sets the ID of the product.
    /// </summary>
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    [JsonPropertyName("productName")]
    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    [JsonPropertyName("productPrice")]
    public decimal ProductPrice { get; set; }

    /// <summary>
    /// Gets or sets the image of the product.
    /// </summary>
    [JsonPropertyName("productImage")]
    public string ProductImage { get; set; } = null!;

    /// <summary>
    /// Gets or sets the overview of the product.
    /// </summary>
    [JsonPropertyName("productOverview")]
    public string ProductOverview { get; set; } = null!;

    /// <summary>
    /// Gets or sets the benefits of the product.
    /// </summary>
    [JsonPropertyName("productBenefits")]
    public string ProductBenefits { get; set; } = null!;
}

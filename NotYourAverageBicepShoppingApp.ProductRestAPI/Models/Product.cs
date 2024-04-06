using System;
using System.Collections.Generic;

namespace NotYourAverageBicepShoppingApp.ProductRestApi.Models;

/// <summary>
/// Represents a product.
/// </summary>
public partial class Product
{
    /// <summary>
    /// Gets or sets the ID of the product.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal ProductPrice { get; set; }
}

﻿using System;
using System.Collections.Generic;

namespace NotYourAverageBicepShoppingApp.CartsRestAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal ProductPrice { get; set; }

    public string ProductImage { get; set; } = null!;

    public string ProductOverview { get; set; } = null!;

    public string ProductBenefits { get; set; } = null!;
}

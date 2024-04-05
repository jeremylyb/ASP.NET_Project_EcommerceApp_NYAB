using System;
using System.Collections.Generic;

namespace NotYourAverageBicepShoppingApp.OrderRestAPI.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = null!;

    public int CartId { get; set; }
}

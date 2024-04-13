using System;
using System.Collections.Generic;

namespace NotYourAverageBicepShoppingApp.OrdersRestAPI.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public string CustomerCreditCardNumber { get; set; } = null!;

    public int CartId { get; set; }
}

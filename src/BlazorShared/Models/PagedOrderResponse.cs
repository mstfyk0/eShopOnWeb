using System.Collections.Generic;

namespace BlazorShared.Models;

public class PagedOrderResponse
{
    public List<Order> Orders { get; set; } = new List<Order>();
}

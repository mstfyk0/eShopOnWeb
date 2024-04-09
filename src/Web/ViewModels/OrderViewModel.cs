using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.Web.Pages.Basket;

namespace Microsoft.eShopWeb.Web.ViewModels;

public class OrderViewModel
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public string CreatedBy { get; set; }
    public int OrderNumber { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    public decimal Total { get; set; }
    public string? Status { get; set; }
    public Address? ShippingAddress { get; set; }
}

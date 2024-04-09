using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Interfaces;

public interface IOrderDetailViewModelService
{
    Task<OrderViewModel> GetOrderById(int id);
}

using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Services;

public class OrderDetailViewModelService : IOrderDetailViewModelService
{
    public Task<OrderViewModel> GetOrderById(int id)
    {
        throw new NotImplementedException();
    }
}

using MediatR;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Web.Features.AllOrders;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.MyOrders;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrders, IEnumerable<OrderViewModel>>
{
    private readonly IReadRepository<Order> _orderRepository;

    public GetAllOrdersHandler(IReadRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderViewModel>> Handle(GetAllOrders request,
        CancellationToken cancellationToken)
    {
        var specification = new AllOrdersSpecification();

        var orders = await _orderRepository.ListAsync(specification);

        return orders.Select(o => new OrderViewModel
        {
            OrderDate = o.OrderDate,
            OrderNumber = o.Id,
            BuyerId = o.BuyerId,
            ShippingAddress = o.ShipToAddress,
            Status = o.Status == false ? "PENDING" : "APPROVED" ,
            Total = o.Total()
        });
    }
}

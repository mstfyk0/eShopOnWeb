using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;

public class OrderWithItemByIdSpec : Specification<Order>
{
    public OrderWithItemByIdSpec(int orderId)
    {
        Query
            .Where(order => order.Id == orderId)
            .Include(order => order.OrderItems);
    }
}


using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;
public class AllOrdersSpecification : Specification<Order>
{
    public AllOrdersSpecification()
    {
        Query.Include(o => o.OrderItems)
                .ThenInclude(i => i.ItemOrdered);
    }
}



using System.Linq;
using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;
public class AllOrderOneOrderItemDetailsSpecification : Specification<OrderItem>
{
    public AllOrderOneOrderItemDetailsSpecification(int id)
    {
        
        Query.Where(o => o.Id == id  );
    }

}

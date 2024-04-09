using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Web.Features.AllOrders;
using Microsoft.eShopWeb.Web.Features.MyOrders;
using Microsoft.eShopWeb.Web.Features.OrderDetails;

namespace Microsoft.eShopWeb.Web.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
[Route("[controller]/[action]")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;
    //private readonly IRepository<Order> _itemRepository;
    private readonly IOrderService _orderService;

    public OrderController(IMediator mediator,
        //IRepository<Order> itemRepository,
        IOrderService orderService
        )
    {
        _mediator = mediator;
        //_itemRepository = itemRepository;
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> MyOrders()
    {   
        Guard.Against.Null(User?.Identity?.Name, nameof(User.Identity.Name));
        var viewModel = await _mediator.Send(new GetMyOrders(User.Identity.Name));

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> AllOrders()
    {   
        // the implementation below using ForEach and Count. We need a List.
        var itemsOnPage = await _mediator.Send( new GetAllOrders(User.Identity.Name));
        return View(itemsOnPage);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> Detail(int orderId)
    {
        Guard.Against.Null(User?.Identity?.Name, nameof(User.Identity.Name));
        var viewModel = await _mediator.Send(new GetOrderDetails(User.Identity.Name, orderId));

        if (viewModel == null)
        {
            return BadRequest("No such order found for this user.");
        }

        return View(viewModel);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> AllOrderDetail(int orderId)
    {
        Guard.Against.Null(User?.Identity?.Name, nameof(User.Identity.Name));
        var viewModel = await _mediator.Send(new GetOrderDetails(User.Identity.Name, orderId));

        if (viewModel == null)
        {
            return BadRequest("No such order found for this user.");
        }

        return View(viewModel);
    }

    [HttpPost("order/all-order-detail/{orderId}")]
    public  async Task<IActionResult> OrderStatusUpdate(int orderId)
    {

        await _orderService.UpdateOrderAsync(orderId);

        if (!ModelState.IsValid )
        {
            return BadRequest("No such order found for this user.");
        }

        return RedirectToAction("all-orders");
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;


namespace BlazorAdmin.Services;

public class OrderService : IOrderService
{
    private readonly HttpService _httpService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(
        HttpService httpService,
        ILogger<OrderService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    //public async Task<CatalogItem> Edit(CatalogItem catalogItem)
    //{
    //    return (await _httpService.HttpPut<EditCatalogItemResult>("catalog-items", catalogItem)).CatalogItem;
    //}


    public async Task<Order> GetById(int id)
    {
        //var brandListTask = _brandService.List();
        //var typeListTask = _typeService.List();
        var itemGetTask = _httpService.HttpGet<EditOrderResult>($"order/{id}");
        //await Task.WhenAll(brandListTask, typeListTask, itemGetTask);
        await Task.WhenAll(itemGetTask);

        //var brands = brandListTask.Result;
        //var types = typeListTask.Result;
        var order = itemGetTask.Result.Order;
        //catalogItem.CatalogBrand = brands.FirstOrDefault(b => b.Id == catalogItem.CatalogBrandId)?.Name;
        //catalogItem.CatalogType = types.FirstOrDefault(t => t.Id == catalogItem.CatalogTypeId)?.Name;
        return order;
    }

    public async Task<List<Order>> List()
    {
        _logger.LogInformation("Fetching catalog items from API.");

        //var brandListTask = _brandService.List();
        //var typeListTask = _typeService.List();
        var itemListTask = _httpService.HttpGet<PagedOrderResponse>($"orders");
        await Task.WhenAll( itemListTask);
        //var brands = brandListTask.Result;
        //var types = typeListTask.Result;
        var items = itemListTask.Result.Orders;
        //foreach (var item in items)
        //{
        //    item.CatalogBrand = brands.FirstOrDefault(b => b.Id == item.CatalogBrandId)?.Name;
        //    item.CatalogType = types.FirstOrDefault(t => t.Id == item.CatalogTypeId)?.Name;
        //}
        return items;
    }
}

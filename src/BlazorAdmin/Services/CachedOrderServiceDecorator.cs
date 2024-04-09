using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;

namespace BlazorAdmin.Services;

public class CachedOrderServiceDecorator : IOrderService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly OrderService _orderService;
    private ILogger<CachedOrderServiceDecorator> _logger;

    public CachedOrderServiceDecorator(ILocalStorageService localStorageService,
        OrderService orderService,
        ILogger<CachedOrderServiceDecorator> logger)
    {
        _localStorageService = localStorageService;
        _orderService = orderService;
        _logger = logger;
    }

    public async Task<List<Order>> List()
    {
        string key = "items";
        var cacheEntry = await _localStorageService.GetItemAsync<CacheEntry<List<Order>>>(key);
        if (cacheEntry != null)
        {
            _logger.LogInformation("Loading items from local storage.");
            if (cacheEntry.DateCreated.AddMinutes(1) > DateTime.UtcNow)
            {
                return cacheEntry.Value;
            }
            else
            {
                _logger.LogInformation($"Loading {key} from local storage.");
                await _localStorageService.RemoveItemAsync(key);
            }
        }

        var items = await _orderService.List();
        var entry = new CacheEntry<List<Order>>(items);
        await _localStorageService.SetItemAsync(key, entry);
        return items;
    }

    //public async Task<CatalogItem> GetById(int id)
    //{
    //    return (await List()).FirstOrDefault(x => x.Id == id);
    //}
    //public async Task<CatalogItem> Edit(CatalogItem catalogItem)
    //{
    //    var result = await _catalogItemService.Edit(catalogItem);
    //    await RefreshLocalStorageList();

    //    return result;
    //}

    //private async Task RefreshLocalStorageList()
    //{
    //    string key = "items";

    //    await _localStorageService.RemoveItemAsync(key);
    //    var items = await _catalogItemService.List();
    //    var entry = new CacheEntry<List<CatalogItem>>(items);
    //    await _localStorageService.SetItemAsync(key, entry);
    //}
}

using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Pages.OrderPage;

public partial class List : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderService OrderService { get; set; }

    //[Microsoft.AspNetCore.Components.Inject]
    //public ICatalogLookupDataService<CatalogBrand> CatalogBrandService { get; set; }

    //[Microsoft.AspNetCore.Components.Inject]
    //public ICatalogLookupDataService<CatalogType> CatalogTypeService { get; set; }

    private List<Order> order = new List<Order>();
    //private List<CatalogType> catalogTypes = new List<CatalogType>();
    //private List<CatalogBrand> catalogBrands = new List<CatalogBrand>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            order = await OrderService.List();
            //catalogTypes = await CatalogTypeService.List();
            //catalogBrands = await CatalogBrandService.List();

            CallRequestRefresh();
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    //private async void DetailsClick(int id)
    //{
    //    await DetailsComponent.Open(id);
    //}

    //private async Task CreateClick()
    //{
    //    await CreateComponent.Open();
    //}

    //private async Task EditClick(int id)
    //{
    //    await EditComponent.Open(id);
    //}

    //private async Task DeleteClick(int id)
    //{
    //    await DeleteComponent.Open(id);
    //}

    private async Task ReloadCatalogItems()
    {
        order = await OrderService.List();
        StateHasChanged();
    }
}

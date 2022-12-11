using Blazored.LocalStorage;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Components;

public partial class TourDetailComponent
{
    [Inject] private TourService _tourService { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }
    [Inject] private AuthenticationStateProvider _authStateProvider { get; set; }
    [Inject] private ILocalStorageService _localStorageService { get; set; }
    [CascadingParameter] private IModalService _modalService { get; set; }
    
    [Inject] private OrderService _orderService { get; set; }

    private TourModel _tourModel;

    private bool ifInWishList;

    [Parameter]
    public TourModel TourModel
    {
        get => _tourModel;
        set
        {
            _tourModel = value;
            StateHasChanged();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var stateAsync = await _authStateProvider.GetAuthenticationStateAsync();
        var orders = await _orderService.GetAll();
        foreach (var order in orders)
        {
            if (order.Username == stateAsync.User.Identity.Name && order.TourId == TourModel.Id && order.IsPaid == false)
            {
                ifInWishList = true;
                break;
            }
        }

        StateHasChanged();
    }

    private async Task Payment()
    {
        var stateAsync = await _authStateProvider.GetAuthenticationStateAsync();
        await _localStorageService.SetItemAsStringAsync("TourId", TourModel.Id.ToString());
        if (stateAsync.User.Identity != null)
            await _localStorageService.SetItemAsStringAsync("Username", stateAsync.User.Identity.Name);
        _navManager.NavigateTo("Payment");
    }

    private async Task WishList()
    {
        var stateAsync = await _authStateProvider.GetAuthenticationStateAsync();
        await _orderService.Create(new OrderModel(TourModel.Id, stateAsync.User.Identity.Name, false));
        _modalService.Show<GreetingsComponent>("");
        ifInWishList = true;
        StateHasChanged();
    }
}
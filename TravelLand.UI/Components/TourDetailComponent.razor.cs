using Blazored.LocalStorage;
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
    
    private TourModel _tourModel;
    
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
        await base.OnInitializedAsync();
        StateHasChanged();
    }

    private async Task Payment()
    {
        var stateAsync =  await _authStateProvider.GetAuthenticationStateAsync();
        await _localStorageService.SetItemAsStringAsync("TourId", TourModel.Id.ToString());
        if (stateAsync.User.Identity != null)
            await _localStorageService.SetItemAsStringAsync("Username", stateAsync.User.Identity.Name);
        _navManager.NavigateTo("Payment");
    }
    
    private async Task WishList()
    {
        var stateAsync =  await _authStateProvider.GetAuthenticationStateAsync();
        await _localStorageService.SetItemAsStringAsync("TourId", TourModel.Id.ToString());
        if (stateAsync.User.Identity != null)
            await _localStorageService.SetItemAsStringAsync("Username", stateAsync.User.Identity.Name);
        _navManager.NavigateTo("Payment");
    }
}
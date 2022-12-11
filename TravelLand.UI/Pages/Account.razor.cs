using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Security.Claims;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages; 

public partial class Account
{
    [Inject] private OrderService _orderService { get; set; }
    [Inject] private AuthenticationStateProvider _authStateProvider { get; set; }
    [Inject] private ILocalStorageService _localStorageService { get; set; }
    [Inject] private UserService _userService { get; set; }
    [Inject] private AuthService _authService { set; get; }
    [Inject] private NavigationManager _navManager { get; set; }
    
    private IEnumerable<TourModel> _history { get; set; } = new List<TourModel>();
    private IEnumerable<TourModel> _wishList { get; set; } = new List<TourModel>();
    
    private bool _isProfileTab = true;
    private bool _isHistoryTab;
    private bool _isWishListTab;

    private UserModel _userModel = new UserModel();

    public UserModel UserModel
    {
        get => _userModel;
        set
        {
            _userModel = value;
            StateHasChanged();
        }
    } 
    
    protected override async Task OnInitializedAsync()
    {
        var stateAsync =  await _authStateProvider.GetAuthenticationStateAsync();
        UserModel = await _userService.GetByUsername(stateAsync.User.Identity.Name);
        _history = await _orderService.GetUserHistoryByUserUsername(UserModel.Username, true);
        _wishList = await _orderService.GetUserHistoryByUserUsername(UserModel.Username, false);
        StateHasChanged();
    }

    protected async Task Logout()
    {
        await _localStorageService.RemoveItemAsync("token");
        await _authStateProvider.GetAuthenticationStateAsync();
        Back();
    }
    
    
    private void Profile()
    {
        _isProfileTab = true;
        _isHistoryTab = false;
        _isWishListTab = false;
    }
    
    
    private void History()
    {
        _isProfileTab = false;
        _isHistoryTab = true;
        _isWishListTab = false;
    }
    
    private void WishList()
    {
        _isProfileTab = false;
        _isHistoryTab = false;
        _isWishListTab = true;
    }
    
    private async Task Delete(Guid tourId)
    {
        await _orderService.Delete(tourId, UserModel.Username, false);
        _wishList = await _orderService.GetUserHistoryByUserUsername(UserModel.Username, false);
        await InvokeAsync(StateHasChanged);
    }
    
    private void Back()
    {
        _navManager.NavigateTo("");
    }
}


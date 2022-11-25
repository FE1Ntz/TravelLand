using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages; 

public partial class AdminPanel 
{
    [Inject] private AuthenticationStateProvider _authStateProvider { get; set; }
    [Inject] private ILocalStorageService _localStorageService { get; set; }
    [Inject] private UserService _userService { get; set; }
    [Inject] private AuthService _authService { set; get; }
    [Inject] private NavigationManager _navManager { get; set; }

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
    }

    protected async Task Logout()
    {
        await _localStorageService.RemoveItemAsync("token");
        await _authStateProvider.GetAuthenticationStateAsync();
        Back();
    }
    
    private void Back()
    {
        _navManager.NavigateTo("");
    }
}
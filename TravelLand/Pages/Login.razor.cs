using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages;

public partial class Login
{
    [Inject] private AuthenticationStateProvider _authStateProvider { get; set; }
    [Inject] private ILocalStorageService _localStorageService { get; set; }
    [Inject] private AuthService _authService { set; get; }
    [Inject] private NavigationManager _navManager { get; set; }

    private UserLoginDto _userLoginDto = new UserLoginDto();
    [Parameter]
    public UserLoginDto UserLoginDto 
    {
        get => _userLoginDto;
        set
        {
            _userLoginDto = value;
            StateHasChanged();
        }
    } 
    
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    private async Task HandleLogin()
    {
        var result = await _authService.Login(UserLoginDto);
        await _localStorageService.SetItemAsync("token", result);
        await _authStateProvider.GetAuthenticationStateAsync();
    }
    
    private void Registration()
    {
        _navManager.NavigateTo("Registration");
    }
    
    private void Back()
    {
        _navManager.NavigateTo("");
    }
}
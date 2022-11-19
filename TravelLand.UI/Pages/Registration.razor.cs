using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages;

public partial class Registration
{
    [Inject] private NavigationManager _navManager { get; set; }
    [Inject] private AuthService _authService { get; set; }

    private UserRegisterDto _userLoginDto = new UserRegisterDto();
    [Parameter]
    public UserRegisterDto UserRegisterDto 
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

    private async Task HandleRegister()
    {
        var result = await _authService.Register(UserRegisterDto);
    }
    
    private void Login()
    {
        _navManager.NavigateTo("Login");
    }
    
    private void Back()
    {
        _navManager.NavigateTo("");
    }
}
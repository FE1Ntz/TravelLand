using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Enums;
using TravelLand.Entities.Models;
using TravelLand.Entities.Models.DtoModels;
using TravelLand.Services;

namespace TravelLand.Pages;

public partial class Login
{
    [Inject] private AuthenticationStateProvider _authStateProvider { get; set; }
    [Inject] private ILocalStorageService _localStorageService { get; set; }
    [Inject] private AuthService _authService { set; get; }
    [Inject] private NavigationManager _navManager { get; set; }
    private string _usernameError;
    private string _passwordError;
    private string _input { get; set; }
 
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
        if (!result.IsSuccess)
        {
            _usernameError = result.Errors["Username"];
            _passwordError = result.Errors["Password"];
            StateHasChanged();
        }
        else
        {
            await _localStorageService.SetItemAsync("token", result.Token);
            await _authStateProvider.GetAuthenticationStateAsync();
            Back();
        }
    }
    
    private void Registration()
    {
        _navManager.NavigateTo("Registration");
    }
    
    private void Back()
    {
        _navManager.NavigateTo("");
    }
    
    private async Task HandleInput(ChangeEventArgs args, InputValueEnum inputValue)
    {
        _input = args.Value.ToString();
        if (inputValue == InputValueEnum.Username && _input != _userLoginDto.Username)
        {
            _usernameError = "";
            StateHasChanged();
        }
        if (inputValue == InputValueEnum.Username && _input != _userLoginDto.Username)
        {
            _passwordError = "";
            StateHasChanged();
        }
    }
}
using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Entities.Models.DtoModels;
using TravelLand.Services;

namespace TravelLand.Pages;

public partial class Registration
{
    [Inject] private NavigationManager _navManager { get; set; }
    [Inject] private AuthService _authService { get; set; }

    private string _input;
    private string _errorMessage;

    private UserRegisterDto _userRegisterDto = new UserRegisterDto();
    [Parameter]
    public UserRegisterDto UserRegisterDto 
    {
        get => _userRegisterDto;
        set
        {
            _userRegisterDto = value;
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
        if (!result.IsSuccess)
        {
            _errorMessage = result.Errors["Username"];
            StateHasChanged();
        }
        else
        {
            Login();
        }
    }
    
    private async Task HandleInput(ChangeEventArgs args)
    {
        _input = args.Value.ToString();
        if (_input != _userRegisterDto.Username)
        {
            _errorMessage = "";
            StateHasChanged();
        }
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
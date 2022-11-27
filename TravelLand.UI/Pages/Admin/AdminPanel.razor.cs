using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using TravelLand.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages.Admin; 

public partial class AdminPanel 
{
    [Inject] private AuthenticationStateProvider _authStateProvider { get; set; }
    [Inject] private ILocalStorageService _localStorageService { get; set; }
    [Inject] private UserService _userService { get; set; }
    [Inject] private AuthService _authService { set; get; }
    [CascadingParameter] private IModalService _modalService { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }
    
    private IEnumerable<UserModel> _users;
    private IEnumerable<UserModel> Users
    {
        get => _users;
        set
        {
            _users = value;
            StateHasChanged();
        }
    }

    private UserModel _userModel = new UserModel();
    
    
    protected override async Task OnInitializedAsync()
    {
        Users = await _userService.GetAll();
    }

    private async Task Logout()
    {
        await _localStorageService.RemoveItemAsync("token");
        await _authStateProvider.GetAuthenticationStateAsync();
        Back();
    }

    private async Task Edit(Guid id)
    {
        var parameters = new ModalParameters().Add("User", Users.Single(u => u.Id == id));
        _modalService.Show<EditUserComponent>("Edit client", parameters);
    }
    
    private async Task Info(Guid id)
    {
        var parameters = new ModalParameters().Add("User", Users.Single(u => u.Id == id));
        _modalService.Show<EditUserComponent>("Client full info", parameters);
    }

    private void Tours()
    {
        _navManager.NavigateTo("AdminPanel/Tours");
    }
    
    private void Back()
    {
        _navManager.NavigateTo("");
    }
}
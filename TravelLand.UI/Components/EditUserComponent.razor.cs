using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Components; 

public partial class EditUserComponent 
{
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;
    [Inject] private UserService _userService { get; set; }
    
    
    private UserModel _user;
    [Parameter]
    public UserModel User
    {
        get => _user;
        set
        {
            _user = value;
            StateHasChanged();
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    private async Task Save()
    {
        var result = await _userService.Update(_user);
        if (result)
        {
           await BlazoredModal.CloseAsync();
        }
        else
        {
            
        }
    }
}
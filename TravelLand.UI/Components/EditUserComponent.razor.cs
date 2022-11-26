using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Components; 

public partial class EditUserComponent 
{
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
}
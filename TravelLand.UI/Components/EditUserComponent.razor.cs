using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Components;

public partial class EditUserComponent
{
    private UserModel _user;
    [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; } = default!;
    [Inject] private UserService _userService { get; set; }

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
    }
}
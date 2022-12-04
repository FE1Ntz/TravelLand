using Blazored.Modal;
using Microsoft.AspNetCore.Components;

namespace TravelLand.Components;

public partial class GreetingsComponent
{
    [Inject] private NavigationManager _navigationManager { get; set; }
    [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(3000);
        await BlazoredModal.CloseAsync();
        _navigationManager.NavigateTo("");
    }
}
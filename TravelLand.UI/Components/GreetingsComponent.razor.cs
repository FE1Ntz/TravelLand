using Blazored.Modal;
using Microsoft.AspNetCore.Components;

namespace TravelLand.Components;

public partial class GreetingsComponent
{
    [Inject] private NavigationManager _navigationManager { get; set; }
    [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(4000);
        await BlazoredModal.CloseAsync();
        if(_navigationManager.ToBaseRelativePath(_navigationManager.Uri) == "Payment")
            _navigationManager.NavigateTo("");
    }
}
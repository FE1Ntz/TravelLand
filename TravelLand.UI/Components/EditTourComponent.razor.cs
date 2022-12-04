using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Components;

public partial class EditTourComponent
{
    private TourModel _tour = new();
    [Inject] private TourService _tourService { get; set; }

    [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; }

    [Parameter]
    public TourModel Tour
    {
        get => _tour;
        set
        {
            _tour = value;
            StateHasChanged();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    private async Task LoadImage(InputFileChangeEventArgs args)
    {
        var file = args.File;
        var buffer = new byte[file.Size];
        await file.OpenReadStream().ReadAsync(buffer);
        Tour.Logo = Convert.ToBase64String(buffer);
        StateHasChanged();
    }

    private async Task Save()
    {
        var result = Tour.Id == Guid.Empty ? await _tourService.Create(Tour) : await _tourService.Update(Tour);

        if (result) await BlazoredModal.CloseAsync();
    }
}
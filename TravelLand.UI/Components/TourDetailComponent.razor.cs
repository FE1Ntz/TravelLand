using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Components;

public partial class TourDetailComponent
{
    [Inject] private TourService _tourService { get; set; }
    
    private TourModel _tourModel;
    
    [Parameter]
    public TourModel TourModel
    {
        get => _tourModel;
        set
        {
            _tourModel = value;
            StateHasChanged();
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        StateHasChanged();
    }
    
}
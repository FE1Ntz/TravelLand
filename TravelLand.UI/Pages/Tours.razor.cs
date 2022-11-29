using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages; 

public partial class Tours 
{
    
    [Inject] private TourService _tourService { get; set; }

    private IEnumerable<TourModel> _tourModels;
    
    public IEnumerable<TourModel> TourModels
    {
        get => _tourModels;
        set
        {
            _tourModels = value;
            StateHasChanged();
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        TourModels = await _tourService.GetAll();
        StateHasChanged();
    }
}
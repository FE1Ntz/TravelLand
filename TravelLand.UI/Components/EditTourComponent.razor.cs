using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Components; 

public partial class EditTourComponent
{
    [Inject] private TourService _tourService { get; set; }
    [CascadingParameter] 
    private BlazoredModalInstance BlazoredModal { get; set; }

    private TourModel _tour = new TourModel();
    
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
    
    private async Task Save()
    {
        // var result = Tour.Id == Guid.Empty ?
        //     await _tourService.Create(Tour) :
        //     await _tourService.Update(Company);

        var result = await _tourService.Create(Tour);
        
        if (result)
        {
            await BlazoredModal.CloseAsync();
        }
        else
        {

        }
    }
}
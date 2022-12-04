using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using TravelLand.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages; 

public partial class Tours 
{
    [CascadingParameter] private IModalService _modalService { get; set; }
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

    protected async Task Details(Guid id)
    {
        var parameters = new ModalParameters().Add("TourModel", await _tourService.GetById(id));
        _modalService.Show<TourDetailComponent>("Tour details", parameters);
    }
}
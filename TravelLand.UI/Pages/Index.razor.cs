using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using TravelLand.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages;

public partial class Index
{
    [CascadingParameter] private IModalService _modalService { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }
    [Inject] private TourService _tourService { get; set; }

    private IEnumerable<TourModel> _tourModels = new List<TourModel>();

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
        var models= await _tourService.GetAll();
        var list = models.ToList();
        var newList = new List<TourModel>();
        for (var x = 0; x < 4; x++)
            newList.Add(list[x]);
        TourModels = newList;
        
        StateHasChanged();
    }

    protected async Task Details(Guid id)
    {
        var parameters = new ModalParameters().Add("TourModel", await _tourService.GetById(id));
        _modalService.Show<TourDetailComponent>("Tour details", parameters);
    }

    private void ToTours()
    {
        _navManager.NavigateTo("/Tours");
    }
}
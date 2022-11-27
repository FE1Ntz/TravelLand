using Blazored.LocalStorage;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using TravelLand.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages.Admin; 

public partial class AdminTours 
{
    [Inject] private AuthenticationStateProvider _authStateProvider { get; set; }
    [Inject] private ILocalStorageService _localStorageService { get; set; }
    [Inject] private AuthService _authService { set; get; }
    [Inject] private TourService _tourService { get; set; }
    [CascadingParameter] private IModalService _modalService { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }
    
    private IEnumerable<TourModel> _tours;
    public IEnumerable<TourModel> Tours
    {
        get => _tours;
        set
        {
            _tours = value;
            StateHasChanged();
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        Tours = await _tourService.GetAll();
    }
    
    private async Task AddTour()
    {
        _modalService.Show<EditTourComponent>("Edit client");
    }

    private async Task Edit(Guid id)
    {
        
    }
    
    private async Task Delete(Guid id)
    {
        
    }
}
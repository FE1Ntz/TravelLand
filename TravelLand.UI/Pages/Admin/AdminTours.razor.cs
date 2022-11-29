using Blazored.LocalStorage;
using Blazored.Modal;
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
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;
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
        var result = _modalService.Show<EditTourComponent>("Edit client");
        var modalResult = await result.Result;
        if (!modalResult.Cancelled)
        {
            Tours = await _tourService.GetAll();
        }
    }

    private async Task Edit(Guid id)
    {
        var parameter = new ModalParameters().Add("Tour", Tours.Single(u => u.Id == id));
        var result = _modalService.Show<EditTourComponent>("Edit client", parameter);
        var modalResult = await result.Result;
        if (!modalResult.Cancelled)
        { 
            await _tourService.GetById(id);
            StateHasChanged();
        }
    }
    
    private async Task Delete(Guid id)
    {
        var result = await _tourService.Delete(id);
        if (result)
        {
            Tours = Tours.Where(t => t.Id != id);
            await InvokeAsync(StateHasChanged);
        }
        else
        {
            
        }
    }

    private async Task AdminPanel()
    {
        _navManager.NavigateTo("/AdminPanel");
    }
    
    private async Task Logout()
    {
        await _localStorageService.RemoveItemAsync("token");
        await _authStateProvider.GetAuthenticationStateAsync();
        Back();
    }
    
    private void Back()
    {
        _navManager.NavigateTo("");
    }
}
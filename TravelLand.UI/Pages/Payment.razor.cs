using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using TravelLand.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Pages;

public partial class Payment
{
    [Inject] private UserService _userService { get; set; }
    [Inject] private TourService _tourService { get; set; }
    [Inject] private OrderService _orderService { get; set; }
    [CascadingParameter] private IModalService _modalService { get; set; }
    [Inject] private ILocalStorageService _localStorageService { get; set; }

    private UserModel _user;
    private TourModel _tour = new TourModel();
    private OrderModel _order;
    private PaymentModel _payment = new PaymentModel();

    [Parameter]
    public PaymentModel PaymentModel
    {
        get => _payment;
        set
        {
            _payment = value;
            StateHasChanged();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var tourId = await _localStorageService.GetItemAsStringAsync("TourId");
        var username = await _localStorageService.GetItemAsStringAsync("Username");
        _tour = await _tourService.GetById(Guid.Parse(tourId));
        _user = await _userService.GetByUsername(username);
        await base.OnInitializedAsync();
    }

    private async Task Pay()
    {
        await _localStorageService.RemoveItemsAsync(new[] { "TourId", "Username"});
        var result = await _orderService.Create(new OrderModel(_tour.Id, _user.Username, true));
        if (result)
        {
            _modalService.Show<GreetingsComponent>("");
        }
    }

    private void TourDetails()
    {
        var paremeters = new ModalParameters().Add("TourModel", _tour);
        _modalService.Show<TourDetailComponent>("Деталі туру", paremeters);
    }
}
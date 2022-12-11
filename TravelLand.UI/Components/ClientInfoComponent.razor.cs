using Microsoft.AspNetCore.Components;
using TravelLand.Entities.Models;
using TravelLand.Services;

namespace TravelLand.Components;

public partial class ClientInfoComponent
{
    
    [Inject] private OrderService _orderService { get; set; }
    [Inject] private TourService _tourService { get; set; }
    private UserModel _user { get; set; }
    private IEnumerable<TourModel> _history { get; set; } = new List<TourModel>();
    private IEnumerable<TourModel> _wishList { get; set; } = new List<TourModel>();

    private bool _isHistoryTab = true;
    private bool _isWishListTab = false;
    
    [Parameter]
    public UserModel User
    {
        get => _user;
        set
        {
            _user = value;
            StateHasChanged();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        _history = await _orderService.GetUserHistoryByUserUsername(User.Username, true);
        _wishList = await _orderService.GetUserHistoryByUserUsername(User.Username, false);
        StateHasChanged();
        
        await base.OnInitializedAsync();
    }

    private void History()
    {
        _isHistoryTab = true;
        _isWishListTab = false;
    }
    
    private void WishList()
    {
        _isHistoryTab = false;
        _isWishListTab = true;
    }
}
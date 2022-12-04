namespace TravelLand.Entities.Models;

public class OrderModel
{
    public Guid Id { get; set; }
    public Guid TourId { get; set; }
    public string Username { get; set; }
    public bool IsPaid { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;

    public OrderModel(Guid tourId, string username, bool isPaid)
    {
        TourId = tourId;
        Username = username;
        IsPaid = isPaid;
    }
}
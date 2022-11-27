namespace TravelLand.Entities.Models; 

public class TourModel 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; } 
    public string Country { get; set; } 
    public string Town { get; set; } 
    public int PersonCount { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Today;
    public DateTime EndDate { get; set; } = DateTime.Today.AddDays(7);
    public int Duration => (EndDate - StartDate).Days;
    public string Description { get; set; }
    
}
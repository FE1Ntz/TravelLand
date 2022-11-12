namespace TravelLand.Entities.Models;

public class UserLoginDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}
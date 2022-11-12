namespace TravelLand.Entities.Models;


public class UserModel
{ 
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

}
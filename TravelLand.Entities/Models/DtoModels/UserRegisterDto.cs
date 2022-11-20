using System.ComponentModel.DataAnnotations;

namespace TravelLand.Entities.Models.DtoModels;

public class UserRegisterDto
{
    [Required(ErrorMessage = "Username is required.")]
    [MinLength(3, ErrorMessage = "Minimum lenght 3 characters")]
    public string Username { get; set; } 
    [Required(ErrorMessage = "Password is required.")]
    [MinLength(3, ErrorMessage = "Minimum lenght 3 characters")]
    public string Password { get; set; }
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }
}
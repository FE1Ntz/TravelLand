namespace TravelLand.Entities.Models.ErrorModels;

public class AuthorizationResponceModel
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public Dictionary<string, string> Errors { get; set; }
    public string Token { get; set; }
}
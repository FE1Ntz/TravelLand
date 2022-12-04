using System.ComponentModel.DataAnnotations;

namespace TravelLand.Entities.Models;

public class PaymentModel
{
    [Required(ErrorMessage = "Input valid card number")]
    [StringLength(16, MinimumLength = 14, ErrorMessage = "Input valid card number")]
    public string CardNumber { get; set; }
    public string ErrorDateMesage => ExpiryDate < DateTime.Now ? "Expired" : "";
    
    public DateTime ExpiryDate { get; set; } = DateTime.Now.AddDays(1);
    [Range(100, 999, ErrorMessage = "Input valid CVV")]
    public int CVV { get; set; }
}
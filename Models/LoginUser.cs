#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace GamePlatform.Models;
public class LoginUser
{
    // No other fields!
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email")]
    public string LoginEmail { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string LoginPassword { get; set; }
}
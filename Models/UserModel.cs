#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GamePlatform.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]
    public string LastName { get; set; }


    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }
    [NotMapped]
    [Required(ErrorMessage = "Confirm password is required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string PasswordConfirm { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

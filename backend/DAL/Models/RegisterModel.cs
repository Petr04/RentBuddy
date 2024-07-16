using System.ComponentModel.DataAnnotations;

namespace RentBuddyBackend.DAL.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public required string Email { get; set; }
    
    [Required]
    [StringLength(32, MinimumLength = 8,  ErrorMessage = "Длина пароля: 8-32")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    
    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [StringLength(32, MinimumLength = 8,  ErrorMessage = "Длина пароля: 8-32")]
    [DataType(DataType.Password)]
    public required string PasswordConfirm { get; set; }

    public bool IsOwner { get; set; } = false;
    
}
using System.ComponentModel.DataAnnotations;

namespace RentBuddyBackend.DAL.Models;

public class AuthModel
{
    [Required]
    public required string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
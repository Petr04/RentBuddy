using System.ComponentModel.DataAnnotations;

namespace RentBuddyBackend.DAL.Models;

public class AuthModel
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
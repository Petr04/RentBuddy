namespace RentBuddyBackend.DAL.Models;

public class AuthReturnModel
{
    public required string Token { get; set; }
    public Guid UserId { get; set; }
}
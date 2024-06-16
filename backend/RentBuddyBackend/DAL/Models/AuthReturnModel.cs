namespace RentBuddyBackend.DAL.Models;

public class AuthReturnModel
{
    public string Token { get; set; }
    public Guid UserId { get; set; }
}
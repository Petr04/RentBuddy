using System.ComponentModel.DataAnnotations;

namespace RentBuddyBackend.DAL.Entities;

public class FavoriteUsersEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public List<Guid>? UsersId { get; set; }

    public FavoriteUsersEntity()
    {
        Id = Guid.NewGuid();
        UsersId = new List<Guid>();  
    }
}
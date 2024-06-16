using System.ComponentModel.DataAnnotations;

namespace RentBuddyBackend.DAL.Entities;

public class BlacklistEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public List<Guid>? UsersId { get; set;}


    public BlacklistEntity()
    {
        Id = Guid.NewGuid();
        UsersId = new List<Guid> {};
    }
}
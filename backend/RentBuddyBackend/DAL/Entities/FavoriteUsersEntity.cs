using System.ComponentModel.DataAnnotations;

namespace RentBuddyBackend.DAL.Entities;

public class FavoriteUsersEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public virtual List<UserEntity>? Users { get; set; }

    public FavoriteUsersEntity(Guid id, List<UserEntity> userEntities)
    {
        Id = id;
        Users = userEntities;  
    }

    public FavoriteUsersEntity(){}
}
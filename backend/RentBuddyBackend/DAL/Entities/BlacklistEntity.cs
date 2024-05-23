using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace RentBuddyBackend.DAL.Entities;

public class BlacklistEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [Ignore, JsonIgnore]
    public virtual List<UserEntity?>? Users { get; } = new List<UserEntity>();

    public BlacklistEntity(Guid id, List<UserEntity> userEntities)
    {
        Id = id;
        Users = userEntities;
    }

    public BlacklistEntity()
    {
            
    }
}
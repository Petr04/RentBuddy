using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;

namespace RentBuddyBackend.DAL.Entities;

public class FavouritesEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }

    [Ignore, JsonIgnore] public virtual List<UserEntity> Users { get; } = new List<UserEntity>();

    public FavouritesEntity(Guid id, List<UserEntity> userEntities)
    {
        Id = id;
        Users = userEntities;  
    }

    public FavouritesEntity()
    {
            
    }
}
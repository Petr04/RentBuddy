using AutoMapper.Configuration.Annotations;
using RentBuddyBackend.Modules.UserModule;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace RentBuddyBackend.DAL.Entities;

public class UserEntity : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime BirthDate { get; set; }
    public GenderType Gender { get; set; }
    public bool IsSmoke { get; set; }
    public bool HasPet { get; set; }
    public int CommunicationLevel { get; set; }
    public int PureLevel { get; set; }
    [DataType(DataType.Time)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
    public DateTime RiseTime { get; set; }
    [DataType(DataType.Time)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
    public DateTime SleepTime { get; set; }
    public TimeSpentAtHome TimeSpentAtHome { get; set; }

    [JsonIgnore]
    public virtual BlacklistEntity? Blacklist { get; set; } 
    [JsonIgnore]
    public virtual FavoriteUsersEntity? FavoriteUsers { get; set; } 
    [JsonIgnore]
    public virtual FavoriteRoomsEntity? FavoriteRooms { get; set; }

    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
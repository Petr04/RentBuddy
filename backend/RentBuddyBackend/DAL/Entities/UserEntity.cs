using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RentBuddyBackend.Modules.UserModule;

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
    public string AboutMe { get; set; }

    [JsonIgnore]
    public Guid BlacklistId { get; set; } 
    [JsonIgnore]
    public Guid FavoriteUsersId { get; set; } 
    [JsonIgnore]
    public Guid FavoriteRoomsId { get; set; }
/*
    [Required(ErrorMessage = "Email is required")]*/
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [JsonIgnore]
    public string? Email { get; set; }
    [JsonIgnore]
    public string? PasswordHash { get; set; }
}

using RentBuddyBackend.Modules.UserModule;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace RentBuddyBackend.DAL.Entities
{
<<<<<<< Updated upstream
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
        
    }
}
=======
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
    public Guid FavoritesUsersId { get; set; } = Guid.Empty;
    public Guid BlacklistId { get; set;} = Guid.Empty;
    
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
    [Ignore, JsonIgnore]
    public virtual BlacklistEntity? Blacklist { get; set; }
    [Ignore, JsonIgnore]
    public virtual FavouritesEntity? Favorites { get; set; }
}
>>>>>>> Stashed changes

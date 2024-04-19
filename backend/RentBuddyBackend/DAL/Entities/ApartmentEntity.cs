using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;

namespace RentBuddyBackend.DAL.Entities;

public class ApartmentEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public int RoomsCount { get; set; }
    public int CurrentFloor { get; set; }
    public int MaxFloor { get; set; }
    
    [Ignore, JsonIgnore]
    public virtual List<RoomEntity> Rooms { get; } = new List<RoomEntity>();
}
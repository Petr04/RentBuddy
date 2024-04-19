using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace RentBuddyBackend.DAL.Entities;

public class RoomEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public int Price { get; set; }
    public int Square { get; set; }
    public int InhabitantsCount { get; set; }
    
    [Ignore, JsonIgnore]
    public virtual ApartmentEntity? Apartment { get; set; }
    
    public Guid? ApartmentId { get; set; }  = Guid.Empty;
}
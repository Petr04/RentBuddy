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
    public string ImageLink { get; set; } = "Images/1.png";
    public Guid? ApartmentId { get; set; }  = Guid.Empty;
    public List<Technic.TechnicType> TechnicTypes { get; set;}
    public List<Furniture.FurnitureType> FurnitureTypes { get; set; }
    public string AboutRoom { get; set; }
    public bool IsPublished { get; set; }

    [Ignore, JsonIgnore]
    public virtual ApartmentEntity? Apartment { get; set; }
}
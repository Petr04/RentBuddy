using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;

namespace RentBuddyBackend.DAL.Entities;

public class ApartmentEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public int CurrentFloor { get; set; }
    public int MaxFloor { get; set; }
    public string Address { get; set; }
    public bool IsCombinedBathroom { get; set; }
    public int BathrooomCount { get; set; }
    public List<Technic.TechnicType> TechnicType { get; set; }
    public bool HasWifi { get; set; }
    public bool HasPassengerElevator { get; set; }
    public bool HasFreightElevator { get; set; }
    /// <summary>
    /// Тип парковки
    /// </summary>
    public Parking.ParkingType ParkingType { get; set; }
    public Yard.YardType YardType { get; set; }
    public bool HasPet { get; set; }
    public bool CanUserSmoke {  get; set; }
    public List<string> ImageLinks { get; set; }
    public string AboutApartment { get; set; }
    public Guid OwnerId { get; set; }

    public virtual List<RoomEntity> Rooms { get; } = new List<RoomEntity>();
}
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.DAL.Models;

public class HostsApartment
{
    public required List<ApartmentEntity> HostsApartments { get; set; }
}
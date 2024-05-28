using AutoMapper;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.RoomModule;

public class RoomMapping : Profile
{
    public RoomMapping()
    {
        CreateMap<RoomEntity, RoomEntity>();
    }
}
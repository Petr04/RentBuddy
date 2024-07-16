using AutoMapper;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.ApartmentModule;

public class ApartmentMapping : Profile
{
    public ApartmentMapping()
    {
        CreateMap<ApartmentEntity, ApartmentEntity>();
    }
}
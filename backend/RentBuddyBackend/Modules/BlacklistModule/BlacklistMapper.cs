using AutoMapper;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.BlacklistModule
{
    public class BlacklistMapper : Profile
    {
        public BlacklistMapper()
        {
            CreateMap<BlacklistEntity, BlacklistEntity>();
        }
    }
}

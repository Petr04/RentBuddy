using AutoMapper;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteUsersModule
{
    public class FavoriteUsersMapper : Profile
    {
        public FavoriteUsersMapper()
        {
            CreateMap<FavoriteUsersEntity, FavoriteUsersEntity>();
        }
    }
}

using AutoMapper;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteUsersModule
{
    public class FavouritesMapper : Profile
    {
        public FavouritesMapper()
        {
            CreateMap<FavoriteUsersEntity, FavoriteUsersEntity>();
        }
    }
}

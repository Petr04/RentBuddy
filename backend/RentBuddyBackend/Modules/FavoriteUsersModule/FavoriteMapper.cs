using AutoMapper;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteUsersModule
{
    public class FavoriteMapper : Profile
    {
        public FavoriteMapper()
        {
            CreateMap<FavouritesEntity, FavouritesEntity>();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteUsersModule.Service
{
    public interface IFavoriteService
    {
        Task<ActionResult<IEnumerable<FavouritesEntity>>> GetFavouritiesList();
        Task<ActionResult<FavouritesEntity>> GetFavouritiesEntity(Guid id);
        Task<ActionResult<FavouritesEntity>> CreateOrUpdateFavouritiesEntity(FavouritesEntity favouritiesEntity);
        Task<ActionResult> DeleteFavourities(Guid id);
        Task<ActionResult> AddFavouritiesUser(Guid currentUserId, Guid targetUserId);
        Task<ActionResult> DeleteFavouritiesUser(Guid currentUserId, Guid targetUserId);
    }
}

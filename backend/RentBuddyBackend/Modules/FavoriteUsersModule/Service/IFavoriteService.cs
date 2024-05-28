using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteUsersModule.Service
{
    public interface IFavoriteService
    {
        Task<ActionResult<IEnumerable<FavoriteUsersEntity>>> GetFavouritiesList();
        Task<ActionResult<FavoriteUsersEntity>> GetFavouritiesEntity(Guid id);
        Task<ActionResult<FavoriteUsersEntity>> CreateOrUpdateFavouritiesEntity(FavoriteUsersEntity favouritiesEntity);
        Task<ActionResult> DeleteFavourities(Guid id);
        Task<ActionResult> AddFavouritiesUser(Guid currentUserId, Guid targetUserId);
        Task<ActionResult> DeleteFavouritiesUser(Guid currentUserId, Guid targetUserId);
    }
}

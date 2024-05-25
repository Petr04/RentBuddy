using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteRooms.Service
{
    public interface IFavoriteRoomsService
    {
        Task<ActionResult> AddRoomToFavorites(Guid roomId, Guid currentUserId);
        Task<ActionResult<FavoriteRoomsEntity>> GetFavoritesRooms(Guid favoritesRoomsId);
        Task<ActionResult<FavoriteRoomsEntity>> CreateFavoriteRooms(FavoriteRoomsEntity favoriteRoomsEntity);
    }
}

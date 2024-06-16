using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.FavoriteRooms.Service;

namespace RentBuddyBackend.Modules.FavoriteRooms
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteRoomsController : ControllerBase
    {   
        private readonly IFavoriteRoomsService service;

        public FavoriteRoomsController(IFavoriteRoomsService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Добавить комнату в избранное
        /// </summary>
        /// <param name="roomsId">Id Комнаты</param>
        /// <param name="currentUserId">Id текущего пользователя</param>
        /// <returns></returns>
        [HttpPost("{currentUserId:Guid}/AddRoomToFavorites")]
        public Task<ActionResult> AddRoomToFavorites([FromBody] List<Guid> roomsId, Guid currentUserId)
            => service.AddRoomToFavorites(roomsId, currentUserId);

        /// <summary>
        /// Получить список избранных комнат
        /// </summary>
        /// <param name="favoritesRoomsId">Id сущности избранных комнат</param>
        /// <returns></returns>
        [HttpGet("{favoritesRoomsId:Guid}")]
        public Task<ActionResult<FavoriteRoomsEntity>> GetFavoritesRooms(Guid favoritesRoomsId)
            => service.GetFavoritesRooms(favoritesRoomsId);
    }
}

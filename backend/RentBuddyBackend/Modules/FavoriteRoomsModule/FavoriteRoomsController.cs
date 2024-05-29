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

        [HttpPost("{currentUserId:Guid}/AddRoomToFavorites")]
        public Task<ActionResult> AddRoomToFavorites([FromBody] List<Guid> roomsId, Guid currentUserId)
            => service.AddRoomToFavorites(roomsId, currentUserId);

        [HttpGet("{favoritesRoomsId:Guid}")]
        public Task<ActionResult<FavoriteRoomsEntity>> GetFavoritesRooms(Guid favoritesRoomsId)
            => service.GetFavoritesRooms(favoritesRoomsId);
    }
}

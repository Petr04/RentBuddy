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

        [HttpPost("AddRoomToFavorites")]
        public Task<ActionResult> AddRoomToFavorites([FromBody] Guid roomId, Guid currentUserId)
            => service.AddRoomToFavorites(roomId, currentUserId);

        [HttpGet("{favoritesRoomsId:Guid}")]
        public Task<ActionResult<FavoriteRoomsEntity>> GetFavoritesRooms(Guid favoritesRoomsId)
            => service.GetFavoritesRooms(favoritesRoomsId);
    }
}

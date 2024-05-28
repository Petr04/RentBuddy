using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;

namespace RentBuddyBackend.Modules.FavoriteUsersModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {

        private readonly IFavoriteService favoriteService;

        public FavouritesController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }
        /*
        [HttpGet]
        public Task<ActionResult<IEnumerable<FavouritesEntity>>> GetFavouritiesList()
            => favoriteService.GetFavouritiesList();

        [HttpDelete("{id:guid}")]
        public Task<ActionResult> DeleteFavourities([FromRoute] Guid id)
            => favoriteService.DeleteFavourities(id);

        [HttpPost]
        public Task<ActionResult<FavouritesEntity>> CreateOrUpdateFavouritiesEntity([FromBody] FavouritesEntity favouritesEntity)
            => favoriteService.CreateOrUpdateFavouritiesEntity(favouritesEntity);
        */
        [HttpGet("{id:guid}")]
        public Task<ActionResult<FavoriteUsersEntity>> GetFavouritiesEntity([FromRoute] Guid id)
         => favoriteService.GetFavouritiesEntity(id); 
        
        [HttpPost("AddUserToFavourities/{targetUserId:Guid}")]
        public Task<ActionResult> AddFavouritiesUser([FromBody] Guid currentUserId, Guid targetUserId)
            => favoriteService.AddFavouritiesUser(currentUserId, targetUserId);

        [HttpPost("DeleteUserFromFavourities/{targetUserId:Guid}")]
        public Task<ActionResult> DeleteFavouritiesUser([FromBody] Guid currentUserId, Guid targetUserId)
            => favoriteService.DeleteFavouritiesUser(currentUserId, targetUserId);    

    }
}

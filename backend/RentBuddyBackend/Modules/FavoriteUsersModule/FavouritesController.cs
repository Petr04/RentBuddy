using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;

namespace RentBuddyBackend.Modules.FavoriteUsersModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase, IFavoriteService
    {

        private readonly IFavoriteService favoriteService;

        public FavouritesController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<FavouritesEntity>>> GetFavouritiesList()
            => favoriteService.GetFavouritiesList();

        [HttpGet("{id:guid}")]
        public Task<ActionResult<FavouritesEntity>> GetFavouritiesEntity([FromRoute] Guid id)
            => favoriteService.GetFavouritiesEntity(id);

        [HttpDelete("{id:guid}")]
        public Task<ActionResult> DeleteFavourities([FromRoute] Guid id)
            => favoriteService.DeleteFavourities(id);

        [HttpPost]
        public Task<ActionResult<FavouritesEntity>> CreateOrUpdateFavouritiesEntity([FromBody] FavouritesEntity favouritesEntity)
            => favoriteService.CreateOrUpdateFavouritiesEntity(favouritesEntity);

        [HttpPost("AddUserToFavourities/{targetUserId:Guid}")]
        public Task<ActionResult> AddFavouritiesUser([FromBody] Guid favouritiesId, Guid targetUserId)
            => favoriteService.AddFavouritiesUser(favouritiesId, targetUserId);

        [HttpPost("DeleteUserFromFavourities/{targetUserId:Guid}")]
        public Task<ActionResult> DeleteFavouritiesUser([FromBody] Guid favouritiesId, Guid targetUserId)
            => favoriteService.DeleteFavouritiesUser(favouritiesId, targetUserId);    

    }
}

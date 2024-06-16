using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;

namespace RentBuddyBackend.Modules.FavoriteUsersModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteUsersController : ControllerBase
    {

        private readonly IFavoriteUsersService favoriteService;

        public FavoriteUsersController(IFavoriteUsersService favoriteService)
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

        /// <summary>
        /// Получить список избранных пользователей по id
        /// </summary>
        /// <param name="id">id сущности избранных пользователей</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public Task<ActionResult<FavoriteUsersEntity>> GetFavouritiesEntity([FromRoute] Guid id)
         => favoriteService.GetFavouritiesEntity(id); 
        
        /// <summary>
        /// Добавить пользователя в список избранного 
        /// </summary>
        /// <param name="currentUserId">Id текущего юзера</param>
        /// <param name="targetUserId">Id Юзера, которого добавляем в список избранного</param>
        /// <returns></returns>
        [HttpPost("{currentUserId:Guid}/AddUserToFavourities/{targetUserId:Guid}")]
        public Task<ActionResult> AddFavouritiesUser([FromRoute] Guid currentUserId, Guid targetUserId)
            => favoriteService.AddFavouritiesUser(currentUserId, targetUserId);

        /// <summary>
        /// Удалить пользователя из списка избранного
        /// </summary>
        /// <param name="currentUserId">Id текущего юзера</param>
        /// <param name="targetUserId">Id юзера, которого убираем из списка избранного</param>
        /// <returns></returns>
        [HttpPost("{currentUserId:Guid}/DeleteUserFromFavourities/{targetUserId:Guid}")]
        public Task<ActionResult> DeleteFavouritiesUser([FromRoute] Guid currentUserId, Guid targetUserId)
            => favoriteService.DeleteFavouritiesUser(currentUserId, targetUserId);    

    }
}

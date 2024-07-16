using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.BlacklistModule.Service;

namespace RentBuddyBackend.Modules.BlacklistModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistController : ControllerBase
    {
        private IBlackListService blackListService;

        public BlacklistController(IBlackListService blackListService)
        {
            this.blackListService = blackListService;
        }

/*        [HttpGet]
        public Task<ActionResult<IEnumerable<BlacklistEntity>>> GetBlacklists()
            => blackListService.GetBlacklists();

        [HttpDelete("{id:guid}")]
        public Task<ActionResult> DeleteBlacklist([FromRoute] Guid id)
            => blackListService.DeleteBlacklist(id);

        [HttpPost]
        public Task<ActionResult<BlacklistEntity>> CreateOrUpdateBlacklist([FromBody] BlacklistEntity BlacklistEntity)
            => blackListService.CreateOrUpdateBlacklist(BlacklistEntity);*/
        

        /// <summary>
        /// Получить черный список по id
        /// </summary>
        /// <param name="id">id черного списка</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public Task<ActionResult<BlacklistEntity>> GetBlacklist([FromRoute] Guid id)
            => blackListService.GetBlacklist(id);

        /// <summary>
        /// Добавить пользователя в черный список 
        /// </summary>
        /// <param name="currentUserId">Текущий юзер</param>
        /// <param name="targetUserId">Тот юзер, кого добавляем в черный список</param>
        /// <returns></returns>
        [HttpPost("{currentUserId:Guid}/AddUserToBlacklist/{targetUserId:Guid}")]
        public Task<ActionResult> AddBlacklistUser([FromRoute] Guid currentUserId, [FromRoute] Guid targetUserId)
            => blackListService.AddBlacklistUser(currentUserId, targetUserId);

        /// <summary>
        /// Удалить пользователя из черного списка 
        /// </summary>
        /// <param name="currentUserId">Текущий юзер</param>
        /// <param name="targetUserId">Юзер, которого удаляем из черного списка</param>
        /// <returns></returns>
        [HttpPost("{currentUserId:Guid}/DeleteUserFromBlacklist/{targetUserId:Guid}")]
        public Task<ActionResult> DeleteBlacklistUser([FromRoute] Guid currentUserId, [FromRoute] Guid targetUserId)
            => blackListService.DeleteBlacklistUser(currentUserId, targetUserId);
    }
}

using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.BlacklistModule.Service;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;

namespace RentBuddyBackend.Modules.BlacklistModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistController : ControllerBase, IBlackListService
    {
        private IBlackListService blackListService;

        public BlacklistController(IBlackListService blackListService)
        {
            this.blackListService = blackListService;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<BlacklistEntity>>> GetBlacklists()
            => blackListService.GetBlacklists();

        [HttpGet("{id:guid}")]
        public Task<ActionResult<BlacklistEntity>> GetBlacklist([FromRoute] Guid id)
            => blackListService.GetBlacklist(id);

        [HttpDelete("{id:guid}")]
        public Task<ActionResult> DeleteBlacklist([FromRoute] Guid id)
            => blackListService.DeleteBlacklist(id);

        [HttpPost]
        public Task<ActionResult<BlacklistEntity>> CreateOrUpdateBlacklist([FromBody] BlacklistEntity BlacklistEntity)
            => blackListService.CreateOrUpdateBlacklist(BlacklistEntity);

        [HttpPost("AddUserToBlacklist/{targetUserId:Guid}")]
        public Task<ActionResult> AddBlacklistUser([FromBody] Guid blacklistId, [FromRoute] Guid targetUserId)
            => blackListService.AddBlacklistUser(blacklistId, targetUserId);

        [HttpPost("DeleteUserFromBlacklist/{targetUserId:Guid}")]
        public Task<ActionResult> DeleteBlacklistUser([FromBody] Guid blacklistId, [FromRoute] Guid targetUserId)
            => blackListService.DeleteBlacklistUser(blacklistId, targetUserId);
    }
}

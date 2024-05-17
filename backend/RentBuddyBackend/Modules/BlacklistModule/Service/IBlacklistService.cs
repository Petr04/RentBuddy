using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.BlacklistModule.Service
{
    public interface IBlackListService
    {
        Task<ActionResult<IEnumerable<BlacklistEntity>>> GetBlacklists();
        Task<ActionResult<BlacklistEntity>> GetBlacklist(Guid id);
        Task<ActionResult<BlacklistEntity>> CreateOrUpdateBlacklist(BlacklistEntity blacklistEntity);
        Task<ActionResult> DeleteBlacklist(Guid id);
        Task<ActionResult> AddBlacklistUser(Guid currentUserId, Guid targetUserId);
        Task<ActionResult> DeleteBlacklistUser(Guid currentUserId, Guid targetUserId);
    }
}

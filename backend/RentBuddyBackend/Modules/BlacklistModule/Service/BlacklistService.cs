using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.BlacklistModule.Repository;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.BlacklistModule.Service
{
    public class BlacklistService : ControllerBase, IBlackListService
    {   
        private IBlacklistRepository blacklistRepository;
        private IUserRepository userRepository;
        private IMapper blacklistMapper;

        public BlacklistService(IBlacklistRepository blacklistRepository, IUserRepository userRepository, IMapper blacklistMapper)
        {
            this.blacklistRepository = blacklistRepository;
            this.userRepository = userRepository;
            this.blacklistMapper = blacklistMapper;
        }

        public async Task<ActionResult> AddBlacklistUser(Guid currentUserId, Guid targetUserId)
        {
            var currentUser = await userRepository.FindAsync(currentUserId);
            var blacklist = await blacklistRepository.FindAsync(currentUser.BlacklistId);
            blacklist.UsersId.Add(targetUserId);
            await blacklistRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult> DeleteBlacklistUser(Guid currentUserId, Guid targetUserId)
        {
            var currentUser = await userRepository.FindAsync(currentUserId);
            var blacklist = await blacklistRepository.FindAsync(currentUser.BlacklistId);
            blacklist.UsersId.Remove(targetUserId);
            await blacklistRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult<BlacklistEntity>> CreateOrUpdateBlacklist(BlacklistEntity blacklistEntity)
        {
            var blacklist = await blacklistRepository.FindAsync(blacklistEntity.Id);
            if (blacklist == null)
                await blacklistRepository.AddAsync(blacklistEntity);
            else
                blacklistMapper.Map(blacklistEntity, blacklist);

            await blacklistRepository.SaveChangesAsync();

            return Ok(blacklist);

        }

        public async Task<ActionResult> DeleteBlacklist(Guid id)
        {
            var blacklist = await blacklistRepository.FindAsync(id);
            blacklistRepository.Remove(blacklist);

            await userRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult<BlacklistEntity>> GetBlacklist(Guid id)
        {
            var blacklist = await blacklistRepository.FindAsync(id);
            if (blacklist == null)
                return NoContent();
            return Ok(blacklist);
        }

        public async Task<ActionResult<IEnumerable<BlacklistEntity>>> GetBlacklists()
        {
            var blacklists = await blacklistRepository.ToListAsync();
            return blacklists;
        }
    }
}

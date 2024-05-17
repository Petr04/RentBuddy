using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.BlacklistModule.Repository;
using RentBuddyBackend.Modules.BlacklistModule.Service;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IBlacklistRepository blacklistRepository;
        private readonly IMapper mapper;
        private readonly IBlackListService blackListService;
        private readonly IFavoriteService favoriteService;

        public UserService
            (
                IUserRepository userRepository,
                IMapper mapper,
                IBlacklistRepository blacklistRepository,
                IBlackListService blackListService,
                IFavoriteService favoriteService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.blacklistRepository = blacklistRepository;
            this.blackListService = blackListService;
            this.favoriteService = favoriteService;
        }

        public async Task<ActionResult<UserEntity>> CreateOrUpdateUser(UserEntity userEntity)
        {
            var user = await userRepository.FindAsync(userEntity.Id);

            if (user == null)
            {
                var blacklistEntity = new BlacklistEntity(Guid.NewGuid(), []);
                await blackListService.CreateOrUpdateBlacklist(blacklistEntity);
                var favouritesEntity = new FavouritesEntity(Guid.NewGuid(), []);
                await favoriteService.CreateOrUpdateFavouritiesEntity(favouritesEntity);
                userEntity.FavoritesUsersId = favouritesEntity.Id;
                userEntity.BlacklistId = blacklistEntity.Id;
                await userRepository.AddAsync(userEntity);
            }
            else
                mapper.Map(userEntity, user);

            await userRepository.SaveChangesAsync();

            return Ok(user);
        }

        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var user = await userRepository.FindAsync(id);
            userRepository.Remove(user);

            await userRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult<UserEntity>> GetUser(Guid id)
        {
            var user = await userRepository.FindAsync(id);
            if (user == null)
                return NoContent();
            
            return Ok(user);
        }

        public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
        {
            var users = await userRepository.ToListAsync();
            return Ok(users);
        }

        public async Task<ActionResult<IEnumerable<UserEntity>>> MatchUser(Guid id)
        {
            var user = await userRepository.FindAsync(id);
            var userBlackList = await blacklistRepository.FindAsync(user.BlacklistId);
            var users = await userRepository.ToListAsync();
            var resultUsers = users.Where(u => !userBlackList.Users.Any(ub => u.Id == ub.Id));
            var matches = Matching.Match(user, resultUsers);
            var matchedUsers = matches.Keys.ToList();
            return Ok(matchedUsers);
        }
    }
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.DAL.Models;
using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.BlacklistModule.Repository;
using RentBuddyBackend.Modules.BlacklistModule.Service;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public class UserService(IUserRepository userRepository,
            IMapper mapper,
            IBlacklistRepository blacklistRepository,
            IBlackListService blackListService,
            IFavoriteService favoriteService,
            IConfiguration configuration,
            AuthService authService)
        : ControllerBase, IUserService
    {
        public async Task<ActionResult<UserEntity>> CreateOrUpdateUser(UserEntity userEntity)
        {
            var user = await userRepository.FindAsync(userEntity.Id);

            if (user == null)
            {
                var blacklistEntity = new BlacklistEntity(Guid.NewGuid(), new List<UserEntity>());
                await blackListService.CreateOrUpdateBlacklist(blacklistEntity);
                var favouritesEntity = new FavouritesEntity(Guid.NewGuid(), new List<UserEntity>());
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
        
        public async Task<ActionResult<UserEntity>> RegisterUser(RegisterModel model)
        {
            if (await userRepository.UserExists(model.Email))
                return BadRequest("Почта зарегистрирована");

            var user = new UserEntity
            {
                Id = Guid.Empty,
                Email = model.Email,
                PasswordHash = AuthService.HashPassword(model.Password),
                Name = "temp",
                Lastname = "temp",
                BirthDate = DateTime.Today,
                Gender = GenderType.Male,
                IsSmoke = false,
                HasPet = false,
                CommunicationLevel = 0,
                PureLevel = 0,
                RiseTime = DateTime.Today,
                SleepTime = DateTime.Today,
            };

            var blacklistEntity = new BlacklistEntity(Guid.Empty, new List<UserEntity>());
            await blackListService.CreateOrUpdateBlacklist(blacklistEntity);
            
            var favouritesEntity = new FavouritesEntity(Guid.Empty, new List<UserEntity>());
            await favoriteService.CreateOrUpdateFavouritiesEntity(favouritesEntity);
            
            user.FavoritesUsersId = favouritesEntity.Id;
            user.BlacklistId = blacklistEntity.Id;

            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
            
            var token = authService.GenerateJwtToken(user);

            return Ok(new { user, token });
        }

        public async Task<ActionResult<string>> AuthUser(AuthModel model)
        {
            var user = await userRepository.FindByEmailAsync(model.Email);
            
            if (user == null || !AuthService.VerifyPassword(model.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials");

            var token = authService.GenerateJwtToken(user);

            return Ok(token);
        }
    }
}

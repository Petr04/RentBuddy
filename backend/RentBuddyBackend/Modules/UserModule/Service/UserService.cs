using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResult<UserEntity>> CreateOrUpdateUser(UserEntity userEntity)
        {
            var user = await userRepository.FindAsync(userEntity.Id);

            if (user == null)
            {
                var blacklistEntity = new BlacklistEntity(userEntity.FavoritesUsersId, new List<UserEntity>());
                await blackListService.CreateOrUpdateBlacklist(blacklistEntity);
                
                var favouritesEntity = new FavouritesEntity(userEntity.BlacklistId, new List<UserEntity>());
                await favoriteService.CreateOrUpdateFavouritiesEntity(favouritesEntity);
                
                /*userEntity.FavoritesUsersId = favouritesEntity.Id;
                userEntity.BlacklistId = blacklistEntity.Id;*/
                await userRepository.AddAsync(userEntity);
                
                user = userEntity;
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
            var users = await userRepository.ToListAsync();
            var matches = Matching.Match(user, users);
            var matchedUsers = matches.Keys.ToList();
            return Ok(matchedUsers);
        }
<<<<<<< Updated upstream
=======
        
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

            var blacklistEntity = new BlacklistEntity(Guid.NewGuid(), new List<UserEntity>());
            await blackListService.CreateOrUpdateBlacklist(blacklistEntity);
            
            var favouritesEntity = new FavouritesEntity(Guid.NewGuid(), new List<UserEntity>());
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
>>>>>>> Stashed changes
    }
}

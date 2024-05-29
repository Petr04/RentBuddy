using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.DAL.Models;
using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.ApartmentModule.Repository;
using RentBuddyBackend.Modules.BlacklistModule.Repository;
using RentBuddyBackend.Modules.BlacklistModule.Service;
using RentBuddyBackend.Modules.FavoriteRooms.Service;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public class UserService(IUserRepository userRepository,
            IApartmentRepository apparmentRepostory,
            IMapper mapper,
            IBlacklistRepository blacklistRepository,
            IBlackListService blackListService,
            IFavoriteService favoriteService,
            IFavoriteRoomsService favoriteRoomsService,
            AuthService authService,
            IMatchingService matchingService)
        : ControllerBase, IUserService
    {
        public async Task<ActionResult<UserEntity>> CreateOrUpdateUser(UserEntity userEntity)
        {
            var user = await userRepository.FindAsync(userEntity.Id);

            if (user == null)
            {
                var blackList =  new BlacklistEntity(Guid.NewGuid(), new List<UserEntity>());
                var favoriteUsers = new FavoriteUsersEntity(Guid.NewGuid(), new List<UserEntity>());
                var favoriteRooms = new FavoriteRoomsEntity(Guid.NewGuid(), new List<RoomEntity>());
                await blackListService.CreateOrUpdateBlacklist(blackList);
                await favoriteService.CreateOrUpdateFavouritiesEntity(favoriteUsers);
                await favoriteRoomsService.CreateFavoriteRooms(favoriteRooms);
                userEntity.Blacklist = blackList;
                userEntity.FavoriteUsers = favoriteUsers;
                userEntity.FavoriteRooms = favoriteRooms;
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
            var userBlackList = await blacklistRepository.FindAsync(user.Blacklist.Id);
            var users = await userRepository.ToListAsync();
            var resultUsers = users.Where(u => !userBlackList.Users.Any(ub => u.Id == ub.Id));
            var matches = matchingService.Match(user, resultUsers);
            var matchedUsers = matches.Keys.ToList();
            
            return Ok(matchedUsers);
        }
        
        public async Task<ActionResult<UserEntity>> RegisterUser(RegisterModel regModel)
        {
            if (await userRepository.UserExists(regModel.Email))
                return BadRequest("Почта с таким именем уже была зарегистрирована");

            var user = new UserEntity
            {
                Id = Guid.Empty,
                Email = regModel.Email,
                PasswordHash = authService.HashPassword(regModel.Password),
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

            await CreateOrUpdateUser(user);
            var token = authService.GenerateJwtToken(user);

            return Ok(new JwtTokenModel { Token = token});
        }

        public async Task<ActionResult<string>> AuthUser(AuthModel model)
        {
            var user = await userRepository.FindByEmailAsync(model.Email);

            if (user == null)
                return NotFound();

            if (!authService.VerifyPassword(model.Password, user.PasswordHash))
                return BadRequest();

            var token = authService.GenerateJwtToken(user);

            return Ok(new JwtTokenModel { Token = token});
        }

        public async Task<ActionResult<UserEntity>> GetCurrentUser()
        {

            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = await userRepository.FindAsync(userId);
            return Ok(user);
                
        }

        public async Task<ActionResult> GetSuitableRoom(Guid id)
        {
            /*            if (User == null)
                            return BadRequest("Пользователь не авторизован");

                        var currentUser = GetCurrentUser().Result.Value;*/
            var currentUser = await userRepository.FindAsync(id);
            var favoriteUsers = currentUser.FavoriteUsers;
            if (favoriteUsers.Users.Count == 0)
                return NoContent();

            var favoriteApartments = currentUser.FavoriteRooms.Rooms.Select(r=> r.Apartment.Id).ToList();
            if (favoriteApartments.Count == 0)
                return NoContent();

            var dictCopy = FavoriteApartmentEntity.UsersFavoriteApartments;
            var keysToRemove = new List<Guid>();
            int i = 0;
            foreach (var kvp in dictCopy)
            {
                if (!kvp.Key.Equals(favoriteApartments[i]))
                    keysToRemove.Add(kvp.Key);

                kvp.Value.Where(u1 => favoriteUsers.Users.Any(u2 => u1 == u2.Id)); // и наоборот
                kvp.Value.Select(u => userRepository.FindAsync(u).Result).Where(u=>u.FavoriteUsers.Users.Contains(currentUser));

                if (kvp.Value.Count() == 0)
                    keysToRemove.Add(kvp.Key);

                i++;
            }

            foreach (var kvp in keysToRemove)
                dictCopy.Remove(kvp);

            if (dictCopy.Count() == 0)
                return NoContent();

            var rand = new Random();
            var favoriteKey = dictCopy.ElementAt(rand.Next(0, dictCopy.Count)).Key;
            var apartmentEntity = await apparmentRepostory.FindAsync(favoriteKey);
            var apartmentRooms = apartmentEntity.Rooms;
            var resultRooms = apartmentRooms.Where(currentUser.FavoriteRooms.Rooms.Contains);

            var resultRoom = resultRooms.ElementAt(rand.Next(0, resultRooms.Count()));
            var resultUsers = dictCopy[favoriteKey].Select(u => userRepository.FindAsync(u).Result).ToList();

            var result = new Tuple<RoomEntity, List<UserEntity>>(resultRoom, resultUsers);
            return Ok(result);
        }
    }
}   

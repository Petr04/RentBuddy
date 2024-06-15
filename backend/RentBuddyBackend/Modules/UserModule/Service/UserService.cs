using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.DAL.Models;
using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.ApartmentModule.Repository;
using RentBuddyBackend.Modules.BlacklistModule.Repository;
using RentBuddyBackend.Modules.BlacklistModule.Service;
using RentBuddyBackend.Modules.FavoriteRooms.Repository;
using RentBuddyBackend.Modules.FavoriteRooms.Service;
using RentBuddyBackend.Modules.FavoriteUsersModule.Repository;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;
using RentBuddyBackend.Modules.RoomModule.Repository;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public class UserService(IUserRepository userRepository,
            IApartmentRepository apparmentRepostory,
            IMapper mapper,
            IBlacklistRepository blacklistRepository,
            IBlackListService blackListService,
            IFavoriteUsersService favoriteService,
            IFavoriteRoomsService favoriteRoomsService,
            AuthService authService,
            IMatchingService matchingService,
            IFavoriteUsersRepository favoriteUsersRepository,
            IFavoriteRoomsRepository favoriteRoomsRepository,
            IRoomRepository roomRepository)
        : ControllerBase, IUserService
    {
        public async Task<ActionResult<UserEntity>> CreateOrUpdateUser(UserEntity userEntity)
        {
            var user = await userRepository.FindAsync(userEntity.Id);

            if (user == null)
            {
                var blackList = new BlacklistEntity();
                var favoriteUsers = new FavoriteUsersEntity();
                var favoriteRooms = new FavoriteRoomsEntity();
                await blackListService.CreateOrUpdateBlacklist(blackList);
                await favoriteService.CreateOrUpdateFavouritiesEntity(favoriteUsers);
                await favoriteRoomsService.CreateFavoriteRooms(favoriteRooms);
                userEntity.BlacklistId = blackList.Id;
                userEntity.FavoriteUsersId = favoriteUsers.Id;
                userEntity.FavoriteRoomsId = favoriteRooms.Id;
                await userRepository.AddAsync(userEntity);
                await userRepository.SaveChangesAsync();
                return userEntity;
            }
            else
            {
                userEntity.BlacklistId = user.BlacklistId;
                userEntity.FavoriteUsersId = user.FavoriteUsersId;
                userEntity.FavoriteRoomsId = user.FavoriteRoomsId;
                userEntity.Email = user.Email;
                userEntity.PasswordHash = user.PasswordHash;
                mapper.Map(userEntity, user);
            }

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
            var resultUsers = users.Where(u => !userBlackList.UsersId.Any(ub => u.Id == ub));
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
                Name = "",
                Lastname = "",
                BirthDate = DateTime.Today,
                Gender = GenderType.Male,
                IsSmoke = false,
                HasPet = false,
                CommunicationLevel = 0,
                PureLevel = 0,
                RiseTime = DateTime.Today,
                SleepTime = DateTime.Today,
                AboutMe = ""
            };

            var newUser = await CreateOrUpdateUser(user);

            return Ok(new RegReturnModel{ UserId = newUser.Value.Id });
        }

        public async Task<ActionResult<Guid>> AuthUser(AuthModel model)
        {
            var user = await userRepository.FindByEmailAsync(model.Email);

            if (user == null)
                return NotFound();

            if (!authService.VerifyPassword(model.Password, user.PasswordHash))
                return BadRequest();
            
            var token = authService.GenerateJwtToken(user);

            return Ok(new AuthReturnModel
            {
                Token = token,
                UserId = user.Id
            });
        }

        public async Task<ActionResult<UserEntity>> GetCurrentUser()
        {

            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = await userRepository.FindAsync(userId);
            return Ok(user);
                
        }


        public async Task<ActionResult<SuitableRoom>> GetSuitableRoom(Guid id) 
        {
            var currentUser = await userRepository.FindAsync(id);
            var idFavoriteUsers = await favoriteUsersRepository.FindAsync(currentUser.FavoriteUsersId);
            var selectedFavoriteUsers = idFavoriteUsers.UsersId.Select(u => userRepository.FindAsync(u).Result);
            var filteredFavoriteUsers = selectedFavoriteUsers
                    .Where(u => favoriteUsersRepository
                    .FindAsync(u.FavoriteUsersId).Result.UsersId
                    .Contains(currentUser.Id) && u.Id != currentUser.Id)
                    .ToList();

            if (filteredFavoriteUsers.Count == 0)
                return NoContent();

            var dict = new Dictionary<RoomEntity, List<List<UserEntity>>>();

            var userFavoriteRooms = favoriteRoomsRepository
                .FindAsync(currentUser.FavoriteRoomsId).Result.RoomsId
                .Select(id => roomRepository.FindAsync(id).Result)
                .ToList();

            var rnd = new Random();

            for (var i = 0; i < userFavoriteRooms.Count; i++)
            {
                dict.Add(userFavoriteRooms[i], new List<List<UserEntity>>());
            }

            foreach (var kvp in dict)
            {
                var apartment = kvp.Key.Apartment;
                for (int i = 0; i < apartment.Rooms.Count; i++)
                {
                    if (apartment.Rooms[i].Id == kvp.Key.Id)
                        continue;
                    else
                    {
                        int count = 0;
                        var currentRoomUsers = new List<UserEntity>();
                        for (int j = 0; j < filteredFavoriteUsers.Count; j++)
                        {
                            var currentFavoriteRooms = favoriteRoomsRepository.FindAsync(filteredFavoriteUsers[j].FavoriteRoomsId).Result.RoomsId;
                            if (currentFavoriteRooms.Contains(apartment.Rooms[i].Id))
                            {
                                currentRoomUsers.Add(filteredFavoriteUsers[j]);
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            break;
                        }
                        dict[kvp.Key].Add(currentRoomUsers);
                    }
                }
            }

            foreach (var kvp in dict)
            {
                var resultUsers = new List<UserEntity>();
                var listsUsers = new List<List<UserEntity>>();
                foreach (var value in kvp.Value)
                {
                    var resUser = GetResultUser(value, rnd, ref resultUsers, ref listsUsers);
                    if (resUser == null)
                        break;
                    resultUsers.Add(resUser);
                }
                if (resultUsers.Count == kvp.Key.Apartment.Rooms.Count - 1)
                {
                    return Ok(new SuitableRoom(kvp.Key, resultUsers));
                }

            }

            return NoContent();
        }

        private UserEntity GetResultUser(List<UserEntity> users, Random rnd, ref List<UserEntity> result, ref List<List<UserEntity>> listsUsers )
        {
            var user = users[rnd.Next(0, users.Count-1)];
            if (result.Contains(user))
            {
                if (users.Count > 1)
                {
                    user = GetRightRandomUser(users, user, rnd);
                }

                if (users.Count == 1)
                {
                    var index = result.IndexOf(user);
                    var prevList = listsUsers[index];
                    if (prevList.Count == 1)
                        return null;
                    user = GetRightRandomUser(prevList, user, rnd);
                }
            }

            listsUsers.Add(users);
            return user;
        }

        private UserEntity GetRightRandomUser(List<UserEntity> currentUsers, UserEntity user, Random rnd)
        {
            currentUsers = currentUsers.Where(u => u != user).ToList();
            user = currentUsers [rnd.Next(0, currentUsers.Count-1)];
            return user;
        }
    }
}   

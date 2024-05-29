using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.FavoriteRooms.Repository;
using RentBuddyBackend.Modules.RoomModule.Repository;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.FavoriteRooms.Service
{
    public class FavoriteRoomsService(
        IFavoriteRoomsRepository favoriteRoomsRepository,
        IUserRepository userRepository,
        IRoomRepository roomRepository
        ) : ControllerBase, IFavoriteRoomsService
    {
        public async Task<ActionResult> AddRoomToFavorites(List<Guid> roomsId, Guid currentUserId)
        {   
            var user =  await userRepository.FindAsync(currentUserId);
            if (user == null)
                return BadRequest("Пользователя не существует");

           
            var favoriteRoomsEntity = await favoriteRoomsRepository.FindAsync(user.FavoriteRoomsId);
            favoriteRoomsEntity.RoomsId.AddRange(roomsId);

            await favoriteRoomsRepository.SaveChangesAsync();

            return NoContent();
        }

        public async Task<ActionResult<FavoriteRoomsEntity>> GetFavoritesRooms(Guid favoritesRoomsId)
        {
            var favoritesRooms = await favoriteRoomsRepository.FindAsync(favoritesRoomsId);
            if (favoritesRooms == null)
                return NoContent();

            return Ok(favoritesRooms);
        }

        public async Task<ActionResult<FavoriteRoomsEntity>> CreateFavoriteRooms(FavoriteRoomsEntity favoriteRoomsEntity)
        {
            var favoriteRooms = await favoriteRoomsRepository.FindAsync(favoriteRoomsEntity.Id);
            if (favoriteRooms == null)
                await favoriteRoomsRepository.AddAsync(favoriteRoomsEntity);
            return Ok(favoriteRoomsEntity);
        }
    }
}

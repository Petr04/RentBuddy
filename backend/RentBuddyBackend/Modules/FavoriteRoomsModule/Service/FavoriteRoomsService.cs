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
        public async Task<ActionResult> AddRoomToFavorites(Guid roomId, Guid currentUserId)
        {   
            var user =  await userRepository.FindAsync(currentUserId);
            if (user == null)
                return BadRequest("Пользователя не существует");

            var targetRoom = await roomRepository.FindAsync(roomId);
            user.FavoriteRooms.Rooms.Add(targetRoom);

            var apartmentId = targetRoom.Apartment.Id;

            AddFavoriteApartment(apartmentId, user.Id);

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

        public void AddFavoriteApartment(Guid apartmentId, Guid userId)
        {
            if (!FavoriteApartmentEntity.UsersFavoriteApartments.ContainsKey(apartmentId))
                FavoriteApartmentEntity.UsersFavoriteApartments.Add(apartmentId, new List<Guid> { userId });
            FavoriteApartmentEntity.UsersFavoriteApartments[apartmentId].Add(userId);
        }
    }
}

using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteRooms.Repository
{
    public interface IFavoriteRoomsRepository
    {
        Task<FavoriteRoomsEntity?> FindAsync(Guid id);
        public Task<int> SaveChangesAsync();
        public Task<EntityEntry<FavoriteRoomsEntity>> AddAsync(FavoriteRoomsEntity favoriteUsersEntity);
        public Task<List<FavoriteRoomsEntity>> ToListAsync();
        public void Remove(FavoriteRoomsEntity FavoriteUsersEntity);
        public EntityEntry<FavoriteRoomsEntity> Update(FavoriteRoomsEntity favoriteUsersEntity);
    }
}

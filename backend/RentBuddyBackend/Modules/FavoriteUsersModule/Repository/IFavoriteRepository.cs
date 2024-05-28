using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteUsersModule.Repository
{
    public interface IFavoriteRepository
    {
        Task<FavoriteUsersEntity?> FindAsync(Guid id);
        public Task<int> SaveChangesAsync();
        public Task<EntityEntry<FavoriteUsersEntity>> AddAsync(FavoriteUsersEntity favoriteUsersEntity);
        public Task<List<FavoriteUsersEntity>> ToListAsync();
        public void Remove(FavoriteUsersEntity FavoriteUsersEntity);
        public EntityEntry<FavoriteUsersEntity> Update(FavoriteUsersEntity favoriteUsersEntity);
    }
}

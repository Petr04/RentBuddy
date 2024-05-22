using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteUsersModule.Repository
{
    public interface IFavoriteRepository
    {
        Task<FavouritesEntity?> FindAsync(Guid id);
        public Task<int> SaveChangesAsync();
        public Task<EntityEntry<FavouritesEntity>> AddAsync(FavouritesEntity favoriteUsersEntity);
        public Task<List<FavouritesEntity>> ToListAsync();
        public void Remove(FavouritesEntity FavoriteUsersEntity);
        public EntityEntry<FavouritesEntity> Update(FavouritesEntity favoriteUsersEntity);
    }
}

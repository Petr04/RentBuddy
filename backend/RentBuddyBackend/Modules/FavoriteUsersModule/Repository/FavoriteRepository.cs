using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteUsersModule.Repository
{
    public class FavoriteRepository(ApplicationDbContext context) : IFavoriteRepository
    {
        public async Task<EntityEntry<FavoriteUsersEntity>> AddAsync(FavoriteUsersEntity favoriteUsersEntity)
            => await context.FavouritesEntities.AddAsync(favoriteUsersEntity);

        public async Task<FavoriteUsersEntity?> FindAsync(Guid id)
            => await context.FavouritesEntities.FindAsync(id);

        public void Remove(FavoriteUsersEntity favoriteUsersEntity)
            => context.FavouritesEntities.Remove(favoriteUsersEntity);

        public async Task<int> SaveChangesAsync()
            => await context.SaveChangesAsync();

        public async Task<List<FavoriteUsersEntity>> ToListAsync()
            => await context.FavouritesEntities.ToListAsync();

        public EntityEntry<FavoriteUsersEntity> Update(FavoriteUsersEntity favoriteUsersEntity)
            => context.FavouritesEntities.Update(favoriteUsersEntity);
    }
}

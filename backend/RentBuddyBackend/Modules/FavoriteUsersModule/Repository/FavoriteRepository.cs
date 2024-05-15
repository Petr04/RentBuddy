using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteUsersModule.Repository
{
    public class FavoriteRepository(ApplicationDbContext context) : IFavoriteRepository
    {
        public async Task<EntityEntry<FavouritesEntity>> AddAsync(FavouritesEntity favoriteUsersEntity)
            => await context.FavouritesEntities.AddAsync(favoriteUsersEntity);

        public async Task<FavouritesEntity?> FindAsync(Guid id)
            => await context.FavouritesEntities.FindAsync(id);

        public void Remove(FavouritesEntity favoriteUsersEntity)
            => context.FavouritesEntities.Remove(favoriteUsersEntity);

        public async Task<int> SaveChangesAsync()
            => await context.SaveChangesAsync();

        public async Task<List<FavouritesEntity>> ToListAsync()
            => await context.FavouritesEntities.ToListAsync();

        public EntityEntry<FavouritesEntity> Update(FavouritesEntity favoriteUsersEntity)
            => context.FavouritesEntities.Update(favoriteUsersEntity);
    }
}

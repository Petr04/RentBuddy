using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.FavoriteRooms.Repository
{
    public class FavoriteRoomsRepository(ApplicationDbContext context) : IFavoriteRoomsRepository
    {
        public async Task<EntityEntry<FavoriteRoomsEntity>> AddAsync(FavoriteRoomsEntity favoriteRoomsEntity)
            => await context.FavoriteRoomsEntities.AddAsync(favoriteRoomsEntity);

        public async Task<FavoriteRoomsEntity?> FindAsync(Guid id)
            => await context.FavoriteRoomsEntities.FindAsync(id);

        public void Remove(FavoriteRoomsEntity favoriteRoomsEntity)
            => context.FavoriteRoomsEntities.Remove(favoriteRoomsEntity);

        public async Task<int> SaveChangesAsync()
            => await context.SaveChangesAsync();

        public async Task<List<FavoriteRoomsEntity>> ToListAsync()
            => await context.FavoriteRoomsEntities.ToListAsync();

        public EntityEntry<FavoriteRoomsEntity> Update(FavoriteRoomsEntity favoriteRoomsEntity)
            => context.FavoriteRoomsEntities.Update(favoriteRoomsEntity);
    }
}

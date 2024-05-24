using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.RoomModule.Repository
{
    public class RoomRepository(ApplicationDbContext context) : IRoomRepository
    {
        public async Task<EntityEntry<RoomEntity>> AddAsync(RoomEntity room)
            => await context.Rooms.AddAsync(room);

        public async Task<RoomEntity> FindAsync(Guid id)
            => await context.Rooms.FindAsync(id);

        public void Remove(RoomEntity roomEntity)
            => context.Rooms.Remove(roomEntity);

        public Task<int> SaveChangesAsync()
            => context.SaveChangesAsync();

        public Task<List<RoomEntity>> ToListAsync()
            => context.Rooms.ToListAsync();

        public EntityEntry<RoomEntity> Update(RoomEntity roomEntity)
            => context.Rooms.Update(roomEntity);
    }
}

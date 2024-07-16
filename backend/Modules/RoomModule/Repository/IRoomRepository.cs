using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.RoomModule.Repository
{
    public interface IRoomRepository
    {
        Task<RoomEntity> FindAsync(Guid id);
        public Task<int> SaveChangesAsync();
        public Task<EntityEntry<RoomEntity>> AddAsync(RoomEntity room);
        public Task<List<RoomEntity>> ToListAsync();
        public void Remove(RoomEntity roomEntity);
        public EntityEntry<RoomEntity> Update(RoomEntity roomEntity);
    }
}

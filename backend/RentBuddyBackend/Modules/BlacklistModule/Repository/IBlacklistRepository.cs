using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.BlacklistModule.Repository
{
    public interface IBlacklistRepository
    {
        Task<BlacklistEntity?> FindAsync(Guid id);
        public Task<int> SaveChangesAsync();
        public Task<EntityEntry<BlacklistEntity>> AddAsync(BlacklistEntity blaclistEntity);
        public Task<List<BlacklistEntity>> ToListAsync();
        public void Remove(BlacklistEntity blacklistEntity);
        public EntityEntry<BlacklistEntity> Update(BlacklistEntity blacklistEntity);
    }
}

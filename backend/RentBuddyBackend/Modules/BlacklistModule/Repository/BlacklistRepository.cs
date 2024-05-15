using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.BlacklistModule.Repository
{
    public class BlacklistRepository(ApplicationDbContext context) : IBlacklistRepository
    {
        public async Task<EntityEntry<BlacklistEntity>> AddAsync(BlacklistEntity blaclistEntity)
            => await context.BlacklistEntites.AddAsync(blaclistEntity);

        public async Task<BlacklistEntity?> FindAsync(Guid id)
            => await context.BlacklistEntites.FindAsync(id);

        public void Remove(BlacklistEntity blacklistEntity)
            => context.BlacklistEntites.Remove(blacklistEntity);

        public async Task<int> SaveChangesAsync()
            => await context.SaveChangesAsync();

        public async Task<List<BlacklistEntity>> ToListAsync()
            => await context.BlacklistEntites.ToListAsync();

        public EntityEntry<BlacklistEntity> Update(BlacklistEntity blaclistEntity)
            => context.BlacklistEntites.Update(blaclistEntity);
    }
}

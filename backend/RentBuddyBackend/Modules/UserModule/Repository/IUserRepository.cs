using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.UserModule.Repository
{
    public interface IUserRepository
    {
        Task<UserEntity?> FindAsync(Guid id);
        public Task<int> SaveChangesAsync();
        public Task<EntityEntry<UserEntity>> AddAsync(UserEntity user);
        public Task<List<UserEntity>> ToListAsync();
        public void Remove(UserEntity userEntity);
        public EntityEntry<UserEntity> Update(UserEntity userEntity);
    }
}

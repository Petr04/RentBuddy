﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.UserModule.Repository
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<UserEntity?> FindAsync(Guid id)
            => await context.Users.FindAsync(id);

        public async Task<int> SaveChangesAsync()
            => await context.SaveChangesAsync();

        public async Task<EntityEntry<UserEntity>> AddAsync(UserEntity? userEntity)
            => await context.Users.AddAsync(userEntity);

        public async Task<List<UserEntity>> ToListAsync()
            => await context.Users.ToListAsync();

        public void Remove(UserEntity? userEntity)
            => context.Users.Remove(userEntity);

        public EntityEntry<UserEntity> Update(UserEntity? userEntity)
            => context.Users.Update(userEntity);
        
        public async Task<UserEntity?> FindByEmailAsync(string email)
            => await context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<bool> UserExists(string email)
            => await context.Users.AnyAsync(u => u.Email == email);
        
        public async Task<List<ApartmentEntity>> FindHostsApartments(Guid id)
            => await context.Apartments
                .Where(a => a.OwnerId == id)
                .ToListAsync();
    }
}

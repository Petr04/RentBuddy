using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.FavoriteUsersModule.Repository;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.FavoriteUsersModule.Service
{
    public class FavoriteService : ControllerBase, IFavoriteService
    {   
        private IFavoriteRepository favoriteUsersRepository;
        private IUserRepository userRepository;
        private IMapper favoriteUsersMapper;

        public FavoriteService(IFavoriteRepository favoriteUsersRepository, IUserRepository userRepository, IMapper favoriteMapper)
        {
            this.favoriteUsersRepository = favoriteUsersRepository;
            this.userRepository = userRepository;
            this.favoriteUsersMapper = favoriteMapper;
        }

        public async Task<ActionResult> AddFavouritiesUser(Guid currentUserId, Guid targetUserId)
        {   
            var currentUser = await userRepository.FindAsync(currentUserId);
            var favourities = await favoriteUsersRepository.FindAsync(currentUser.FavoriteUsers.Id);
            var targetUser = await userRepository.FindAsync(targetUserId);
            favourities.Users.Add(targetUser);
            await favoriteUsersRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult> DeleteFavouritiesUser(Guid currentUserId, Guid targetUserId)
        {
            var currentUser = await userRepository.FindAsync(currentUserId);
            var favourities = await favoriteUsersRepository.FindAsync(currentUser.FavoriteUsers.Id);
            var targetUser = await userRepository.FindAsync(targetUserId);
            favourities.Users.Remove(targetUser);
            await favoriteUsersRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult<FavoriteUsersEntity>> CreateOrUpdateFavouritiesEntity(FavoriteUsersEntity favouritesEntity)
        {
            var favourities = await favoriteUsersRepository.FindAsync(favouritesEntity.Id);
            if (favourities == null)
                await favoriteUsersRepository.AddAsync(favouritesEntity);
            else
                favoriteUsersMapper.Map(favouritesEntity, favourities);

            await favoriteUsersRepository.SaveChangesAsync();

            return Ok(favourities);
        }

        public async Task<ActionResult> DeleteFavourities(Guid id)
        {
            var favourities = await favoriteUsersRepository.FindAsync(id);
            favoriteUsersRepository.Remove(favourities);

            await userRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult<FavoriteUsersEntity>> GetFavouritiesEntity(Guid id)
        {
            var favourities = await favoriteUsersRepository.FindAsync(id);
            if (favourities == null)
                return NoContent();
            return Ok(favourities);
        }

        public async Task<ActionResult<IEnumerable<FavoriteUsersEntity>>> GetFavouritiesList()
        {
            var favourities = await favoriteUsersRepository.ToListAsync();
            return favourities;
        }
    }
}

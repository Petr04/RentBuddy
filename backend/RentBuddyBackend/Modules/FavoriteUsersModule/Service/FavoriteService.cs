using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<ActionResult> AddFavouritiesUser(Guid FavouritesId, Guid targetUserId)
        {
            var favourities = await favoriteUsersRepository.FindAsync(FavouritesId);
            var targetUser = await userRepository.FindAsync(targetUserId);
            favourities.Users.Add(targetUser);
            await favoriteUsersRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult> DeleteFavouritiesUser(Guid FavouritesId, Guid targetUserId)
        {
            var favourities = await favoriteUsersRepository.FindAsync(FavouritesId);
            var targetUser = await userRepository.FindAsync(targetUserId);
            favourities.Users.Remove(targetUser);
            await favoriteUsersRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult<FavouritesEntity>> CreateOrUpdateFavouritiesEntity(FavouritesEntity favouritesEntity)
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

        public async Task<ActionResult<FavouritesEntity>> GetFavouritiesEntity(Guid id)
        {
            var favourities = await favoriteUsersRepository.FindAsync(id);
            if (favourities == null)
                return NoContent();
            return Ok(favourities);
        }

        public async Task<ActionResult<IEnumerable<FavouritesEntity>>> GetFavouritiesList()
        {
            var favourities = await favoriteUsersRepository.ToListAsync();
            return favourities;
        }
    }
}

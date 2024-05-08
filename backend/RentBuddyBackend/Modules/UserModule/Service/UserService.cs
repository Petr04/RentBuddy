using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResult<UserEntity>> CreateOrUpdateUser(UserEntity userEntity)
        {
            var user = await userRepository.FindAsync(userEntity.Id);

            if (user == null)
                await userRepository.AddAsync(userEntity);
            else
                mapper.Map(userEntity, user);

            await userRepository.SaveChangesAsync();

            return Ok(user);
        }

        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var user = await userRepository.FindAsync(id);
            userRepository.Remove(user);

            await userRepository.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult<UserEntity>> GetUser(Guid id)
        {
            var user = await userRepository.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
        {
            var users = await userRepository.ToListAsync();
            return Ok(users);
        }
    }
}

using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Infrastructure;
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
                return NoContent();
            
            return Ok(user);
        }

        public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
        {
            var users = await userRepository.ToListAsync();
            return Ok(users);
        }

        public async Task<ActionResult<IEnumerable<UserEntity>>> MatchUser(Guid id)
        {
            var user = await userRepository.FindAsync(id);
            var users = await userRepository.ToListAsync();
            var matches = Matching.Match(user, users);
            var matchedUsers = matches.Keys.ToList();
            return Ok(matchedUsers);
        }
    }
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.DAL.Models;
using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.BlacklistModule.Repository;
using RentBuddyBackend.Modules.BlacklistModule.Service;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public class UserService(IUserRepository userRepository,
            IMapper mapper,
            IBlacklistRepository blacklistRepository,
            IBlackListService blackListService,
            IFavoriteService favoriteService,
            IConfiguration configuration)
        : ControllerBase, IUserService
    {
        public async Task<ActionResult<UserEntity>> CreateOrUpdateUser(UserEntity userEntity)
        {
            var user = await userRepository.FindAsync(userEntity.Id);

            if (user == null)
            {
                var blacklistEntity = new BlacklistEntity(Guid.NewGuid(), new List<UserEntity>());
                await blackListService.CreateOrUpdateBlacklist(blacklistEntity);
                var favouritesEntity = new FavouritesEntity(Guid.NewGuid(), new List<UserEntity>());
                await favoriteService.CreateOrUpdateFavouritiesEntity(favouritesEntity);
                userEntity.FavoritesUsersId = favouritesEntity.Id;
                userEntity.BlacklistId = blacklistEntity.Id;
                await userRepository.AddAsync(userEntity);
            }
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
            var userBlackList = await blacklistRepository.FindAsync(user.BlacklistId);
            var users = await userRepository.ToListAsync();
            var resultUsers = users.Where(u => !userBlackList.Users.Any(ub => u.Id == ub.Id));
            var matches = Matching.Match(user, resultUsers);
            var matchedUsers = matches.Keys.ToList();
            return Ok(matchedUsers);
        }
        
        public async Task<(bool Success, string[] Errors, UserEntity? User)> RegisterUser(RegisterModel model)
        {
            if (await userRepository.UserExists(model.Email))
                return (false, new[] { "User already exists" }, null);

            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                PasswordHash = HashPassword(model.Password)
            };

            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
    
            return (true, Array.Empty<string>(), user);
        }

        public async Task<(bool Success, string[] Errors, string? Token)> AuthUser(AuthModel model)
        {
            var user = await userRepository.FindByEmailAsync(model.Email);
            if (user == null || !VerifyPassword(model.Password, user.PasswordHash))
                return (false, new[] { "Invalid credentials" }, null);

            var token = GenerateJwtToken(user);

            return (true, Array.Empty<string>(), token);
        }
        
        string HashPassword(string password)
        {
            using var hmac = new HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        bool VerifyPassword(string password, string hashedPassword)
        {
            using var hmac = new HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash) == hashedPassword;
        }

        string GenerateJwtToken(UserEntity user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

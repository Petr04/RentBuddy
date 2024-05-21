using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.DAL.Models;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public interface IUserService
    {
        Task<ActionResult<IEnumerable<UserEntity>>> GetUsers();
        Task<ActionResult<UserEntity>> GetUser(Guid id);
        Task<ActionResult<UserEntity>> CreateOrUpdateUser(UserEntity userEntity);
        Task<ActionResult> DeleteUser(Guid id);
        Task<ActionResult<IEnumerable<UserEntity>>> MatchUser(Guid id);
        Task<(bool Success, string[] Errors, UserEntity? User)> RegisterUser(RegisterModel model);
        Task<(bool Success, string[] Errors, string? Token)> AuthUser(AuthModel model);
    }
}

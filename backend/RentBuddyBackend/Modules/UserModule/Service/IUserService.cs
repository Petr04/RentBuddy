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
        Task<ActionResult<UserEntity>> RegisterUser(RegisterModel model);
        Task<ActionResult<string>> AuthUser(AuthModel model);
        Task<ActionResult> GetSuitableRoom(Guid id);
    }
}

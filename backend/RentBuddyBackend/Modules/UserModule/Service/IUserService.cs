using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public interface IUserService
    {
        Task<ActionResult<IEnumerable<UserEntity>>> GetUsers();
        Task<ActionResult<UserEntity>> GetUser(Guid id);
        Task<ActionResult<UserEntity>> CreateOrUpdateUser(UserEntity userEntity);
        Task<ActionResult> DeleteUser(Guid id);
    }
}

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
        Task<ActionResult<UserEntity>> RegisterUser(RegisterModel regModel);
        Task<ActionResult<Guid>> AuthUser(AuthModel model);
        Task<ActionResult> AuthUserWithGoogle(string credential);
        Task<ActionResult<SuitableRoom>> GetSuitableRoom(Guid id);
        Task<ActionResult<IEnumerable<ApartmentEntity>>> GetHostsApartment(Guid id);
    }
}

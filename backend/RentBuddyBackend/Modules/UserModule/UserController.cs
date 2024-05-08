using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.UserModule.Service;

namespace RentBuddyBackend.Modules.UserModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService usersService;

        public UsersController(IUserService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
            => usersService.GetUsers();

        [HttpGet("{id}")]
        public Task<ActionResult<UserEntity>> GetUser([FromRoute] Guid id)
            => usersService.GetUser(id);

        [HttpDelete("{id}")]
        public Task<ActionResult> DeleteUser([FromRoute] Guid id)
            => usersService.DeleteUser(id);

        [HttpPost]
        public Task<ActionResult<UserEntity>> CreateOrUpdateUser([FromBody] UserEntity userEntity)
            => usersService.CreateOrUpdateUser(userEntity);
    }
}

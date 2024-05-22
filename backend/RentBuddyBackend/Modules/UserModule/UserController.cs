using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.DAL.Models;
using RentBuddyBackend.Modules.UserModule.Service;

namespace RentBuddyBackend.Modules.UserModule;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService usersService) : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
        => usersService.GetUsers();

    [HttpGet("{id:guid}")]
    public Task<ActionResult<UserEntity>> GetUser([FromRoute] Guid id)
        => usersService.GetUser(id);

    [HttpDelete("{id:guid}")]
    public Task<ActionResult> DeleteUser([FromRoute] Guid id)
        => usersService.DeleteUser(id);

    [HttpPost]
    public Task<ActionResult<UserEntity>> CreateOrUpdateUser([FromBody] UserEntity userEntity)
        => usersService.CreateOrUpdateUser(userEntity);
        
    [HttpGet("{id:guid}/matches")]
    public Task<ActionResult<IEnumerable<UserEntity>>> MatchUser([FromRoute] Guid id)
        => usersService.MatchUser(id);

    [HttpPost("register")]
    public Task<ActionResult<UserEntity>> Register([FromBody] RegisterModel model)
        => usersService.RegisterUser(model);

    [HttpPost("login")]
    public Task<ActionResult<string>> Login([FromBody] AuthModel model)
        => usersService.AuthUser(model);
}
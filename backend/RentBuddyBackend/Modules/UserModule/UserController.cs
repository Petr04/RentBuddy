using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.DAL.Models;
using RentBuddyBackend.Modules.UserModule.Service;

namespace RentBuddyBackend.Modules.UserModule;

/// <summary>
/// Управление пользователем
/// </summary>
/// <param name="usersService"></param>
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


    /// <summary>
    /// rega
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("register")]  
    public Task<ActionResult<UserEntity>> Register([FromBody] RegisterModel model)
        => usersService.RegisterUser(model);


    /// <summary>
    /// Вход в личный кабинет
    /// </summary>
    /// <param name="model">login</param>
    /// <returns></returns>
    [HttpPost("login")]
    public Task<ActionResult<Guid>> Login([FromBody] AuthModel model)
        => usersService.AuthUser(model);

    /// <summary>
    /// Подбор подходящей комнаты
    /// </summary>
    /// <remarks>
    /// Возвращает RoomEntity и список юзеров(соседей), если пусто, значит такой комнаты или соседей не нашлось
    /// </remarks>
    /// <param name="id"> Id Юзера</param>
    /// <returns></returns>
    [HttpGet("GetSuitableRoom/{id:guid}")]
    public Task<ActionResult<SuitableRoom>> GetSuitableRoom(Guid id)
        => usersService.GetSuitableRoom(id);
}
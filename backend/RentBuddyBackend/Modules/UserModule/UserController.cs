using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.DAL.Models;
using RentBuddyBackend.Modules.UserModule.Service;

namespace RentBuddyBackend.Modules.UserModule;


[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService usersService) : ControllerBase
{
    
    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
        => usersService.GetUsers();

    /// <summary>
    /// Получить пользователя по id
    /// </summary>
    /// <param name="id">id пользователя</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public Task<ActionResult<UserEntity>> GetUser([FromRoute] Guid id)
        => usersService.GetUser(id);

    /// <summary>
    /// Удалить пользователя по id
    /// </summary>
    /// <param name="id">id пользователя</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public Task<ActionResult> DeleteUser([FromRoute] Guid id)
        => usersService.DeleteUser(id);

    /// <summary>
    /// Создание или обновление пользователя
    /// </summary>
    /// <param name="userEntity"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<ActionResult<UserEntity>> CreateOrUpdateUser([FromBody] UserEntity userEntity)
        => usersService.CreateOrUpdateUser(userEntity);
        
    [HttpGet("{id:guid}/matches")]
    public Task<ActionResult<IEnumerable<UserEntity>>> MatchUser([FromRoute] Guid id)
        => usersService.MatchUser(id);

    /// <summary>
    /// Регистрация
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
    /// Возвращает RoomEntity и список юзеров(соседей), если пусто, значит такой комнаты или соседей не нашлось.
    /// Условия выполнения алгоритма:
    /// 1. Текущий пользователь должен быть в избранном у остальных
    /// 2. У текущего и остальных должны быть выбраны комнаты в одной и той же квартире
    /// </remarks>
    /// <param name="id"> Id Юзера</param>
    /// <returns></returns>
    [HttpGet("GetSuitableRoom/{id:guid}")]
    public Task<ActionResult<SuitableRoom>> GetSuitableRoom(Guid id)
        => usersService.GetSuitableRoom(id);
    
    
    /// <summary>
    /// Вывод квартир хозяина
    /// </summary>
    /// <param name="id"> Id Юзера, хозяина квартира</param>
    /// <returns></returns>
    [HttpGet("{id:guid}/GetHostsApartment")]
    public Task<ActionResult<IEnumerable<ApartmentEntity>>> GetHostsApartments([FromRoute] Guid id)
        => usersService.GetHostsApartment(id);
}
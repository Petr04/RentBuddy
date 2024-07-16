using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.RoomModule;

[ApiController]
[Route("api/[controller]")]
public class RoomController(
    ApplicationDbContext context,
    IWebHostEnvironment webHostEnvironment,
    IMapper mapper) : ControllerBase
{   
    
    /// <summary>
    /// Получить все комнаты
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomEntity>>> GetRooms()
    {
        var data = await context.Rooms.ToListAsync();
        
        return Ok(data);
    }

    /// <summary>
    /// Получить все опубликованные комнаты
    /// </summary>
    /// <returns></returns>
    [HttpGet("PublishedRooms")]
    public async Task<ActionResult<IEnumerable<RoomEntity>>> GetPublishedRooms()
    {
        var data = await context.Rooms.ToListAsync();
        var publishedRooms = data.Where(r => r.IsPublished).ToList();
        return Ok(publishedRooms);
    }

    /// <summary>
    /// Получить комнату по id
    /// </summary>
    /// <param name="id">id комнаты</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RoomEntity>> GetRoom([FromRoute] Guid id)
    {
        var data = await context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

        return Ok(data);
    }

    /// <summary>
    /// Создание или обновление комнаты
    /// </summary>
    /// <param name="room">Сущность комнаты</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<RoomEntity>> CreateOrUpdateRoom([FromBody] RoomEntity room)
    {
        var dbEntity = await context.Rooms.FindAsync(room.Id);
        var isCreated = dbEntity != null;

        if (isCreated)
            mapper.Map(room, dbEntity);
        else
        {
            room.Id = Guid.Empty;
            await context.Rooms.AddAsync(room);
        }
        
        await context.SaveChangesAsync();

        return Ok(new CreatedOrUpdateResponse
        {
            Id = room.Id,
            IsCreated = isCreated
        });
    }

    /// <summary>
    /// Удалить комнату по id 
    /// </summary>
    /// <param name="id">id комнаты</param>
    /// <returns></returns>
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteRoom([FromRoute] Guid id)
    {
        var data = await context.Rooms.FindAsync(id);

        if (data == null)
            return NoContent();

        context.Rooms.Remove(data);
        await context.SaveChangesAsync();

        return NoContent();
    }
    
    /// <summary>
    /// Получить изображение комнаты
    /// </summary>
    /// <param name="id">id комнаты</param>
    /// <returns></returns>
    [HttpGet("{id:Guid}/image")]
    public async Task<ActionResult> GetRoomImage([FromRoute] Guid id)
    {
        var data = await context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        
        if (data == null)
            return NoContent();
        
        var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "Image", data.ImageLink.TrimStart('/'));
        
        var imageData = await System.IO.File.ReadAllBytesAsync(imagePath);
        return File(imageData, "image/jpeg");
    }
    

    
}
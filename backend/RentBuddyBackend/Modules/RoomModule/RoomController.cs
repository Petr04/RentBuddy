﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.RoomModule;

[ApiController]
[Route("api/[controller]")]
public class RoomController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomEntity>>> GetRooms()
    {
        var data = await context.Rooms.ToListAsync();
        
        return Ok(data);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RoomEntity>> GetRoom([FromRoute] Guid id)
    {
        var data = await context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<RoomEntity>> CreateOrUpdateRoom([FromBody] RoomEntity room)
    {
        room.Id = Guid.Empty;
        await context.Rooms.AddAsync(room);
        await context.SaveChangesAsync();

        return Ok(new CreatedOrUpdateResponse
        {
            Id = room.Id,
        });
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteRoom([FromRoute] Guid id)
    {
        var data = await context.Rooms.FindAsync(id);

        if (data == null)
            return Ok("Current room doesn't exist");

        context.Rooms.Remove(data);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
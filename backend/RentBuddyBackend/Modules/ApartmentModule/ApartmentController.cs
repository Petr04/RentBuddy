﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.DAL.Models;

namespace RentBuddyBackend.Modules.ApartmentModule;

[ApiController]
[Route("api/[controller]")]
public class ApartmentController(ApplicationDbContext context, IMapper mapper) : ControllerBase
{   
    /// <summary>
    /// Получить все квартиры
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApartmentEntity>>> GetApartment()
    {
        var data = await context.Apartments.ToListAsync();

        return Ok(data);
    }

    /// <summary>
    /// Получить квартиру по id
    /// </summary>
    /// <param name="id">id квартиры</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApartmentEntity>> GetApartment([FromRoute] Guid id)
    {
        var data = await context.Apartments.FirstOrDefaultAsync(a => a.Id == id);

        return Ok(data);
    }

    /// <summary>
    /// Создание или обновление квартиры
    /// </summary>
    /// <param name="apartment">Сущность квартиры</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ApartmentEntity>> CreateOrUpdateApartment([FromBody] ApartmentEntity apartment)
    {
        var dbEntity = await context.Apartments.FindAsync(apartment.Id);
        var isCreated = dbEntity != null;

        if (isCreated)
            mapper.Map(apartment, dbEntity);
        else
        {
            apartment.Id = Guid.Empty;
            await context.Apartments.AddAsync(apartment);
        }

        await context.SaveChangesAsync();

        return Ok(new CreatedOrUpdateResponse
        {
            Id = apartment.Id,
            IsCreated = isCreated
        });
    }

    /// <summary>
    /// Удалить квартиру по id
    /// </summary>
    /// <param name="id">id квартиры</param>
    /// <returns></returns>
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteApartment([FromRoute] Guid id)
    {
        var data = await context.Apartments
            .Include(a => a.Rooms)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (data == null)
            return Ok("Current apartment doesn't exist");

        context.Apartments.Remove(data);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
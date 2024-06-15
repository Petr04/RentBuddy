using AutoMapper;
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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApartmentEntity>>> GetApartment()
    {
        var data = await context.Apartments.ToListAsync();

        return Ok(data);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApartmentEntity>> GetApartment([FromRoute] Guid id)
    {
        var data = await context.Apartments.FirstOrDefaultAsync(a => a.Id == id);

        return Ok(data);
    }

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

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteApartment([FromRoute] Guid id)
    {
        var data = await context.Apartments.FindAsync(id);

        if (data == null)
            return Ok("Current apartment doesn't exist");

        context.Apartments.Remove(data);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id:guid}/gethostsapatment")]
    public async Task<ActionResult<ApartmentEntity>> GetHostsApartments([FromRoute] Guid id)
    {
        var data = await context.Apartments
            .Where(a => a.OwnerId == id)
            .ToListAsync();

        var result = new HostsApartment
        {
            HostsApartments = data
        };

        if (result.HostsApartments.Count == 0)
            return NoContent();

        return Ok(result);
    }
}
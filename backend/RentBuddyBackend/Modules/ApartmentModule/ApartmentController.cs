using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.ApartmentModule;

[ApiController]
[Route("api/[controller]")]
public class ApartmentController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApartmentEntity>>> GetApartment()
    {
        var data = await context.Apartments.ToListAsync();

        if (data.Count == 0)
            return Ok("Apartment's database is empty");

        return Ok(data);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApartmentEntity>> GetApartment([FromRoute] ApartmentEntity apartment)
    {
        var data = await context.Apartments.FirstOrDefaultAsync(a => a.Id == apartment.Id);

        if (data == null)
            return Ok("Current apartment doesn't exist");
        
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<ApartmentEntity>> CreateOrUpdateApartment([FromBody] ApartmentEntity apartment)
    {
        apartment.Id = Guid.Empty;
        await context.Apartments.AddAsync(apartment);
        await context.SaveChangesAsync();
        
        return Ok(new CreatedOrUpdateResponse
        {
            Id = apartment.Id,
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
}
using RentBuddyBackend.DAL;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.ApartmentModule.Repository
{
    public class ApartmentRepository(ApplicationDbContext context) : IApartmentRepository
    {
        public async Task<ApartmentEntity?> FindAsync(Guid id)
            =>  await context.Apartments.FindAsync(id);
    }
}

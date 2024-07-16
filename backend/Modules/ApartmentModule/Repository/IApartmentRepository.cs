using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.ApartmentModule.Repository
{
    public interface IApartmentRepository
    {
        public Task<ApartmentEntity?> FindAsync(Guid id);
    }
}

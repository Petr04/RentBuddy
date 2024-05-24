
namespace RentBuddyBackend.DAL.Entities
{
    public class FavoriteApartmentEntity : IEntity
    {
        public Guid Id { get; set; }
        public static Dictionary<Guid, List<Guid>> UsersFavoriteApartments { get; set; } = new Dictionary<Guid, List<Guid>>(); //key-apartmentId,value-list<usersid> 
    }
}
    
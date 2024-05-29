
namespace RentBuddyBackend.DAL.Entities
{
    public class FavoriteRoomsEntity : IEntity
    {
        public Guid Id { get; set; }
        public List<Guid> RoomsId { get; set; }

        public FavoriteRoomsEntity()
        {
            Id = Guid.NewGuid();
            RoomsId = new List<Guid>();
        }
    }
}

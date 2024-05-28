
namespace RentBuddyBackend.DAL.Entities
{
    public class FavoriteRoomsEntity : IEntity
    {
        public Guid Id { get; set; }
        public virtual List<RoomEntity>? Rooms { get; set; }

        public FavoriteRoomsEntity(Guid Id, List<RoomEntity> Rooms)
        {
            this.Id = Id;
            this.Rooms = Rooms;
        }
        public FavoriteRoomsEntity()
        {
            
        }
    }
}

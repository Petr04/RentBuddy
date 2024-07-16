namespace RentBuddyBackend.DAL.Entities
{
    public class SuitableRoom
    {
        public RoomEntity RoomEntity {  get; set; }

        public List<UserEntity> Users { get; set; }

        public SuitableRoom(RoomEntity roomEntity, List<UserEntity> users)
        {
            this.RoomEntity = roomEntity;
            this.Users = users;
        }
    }
}

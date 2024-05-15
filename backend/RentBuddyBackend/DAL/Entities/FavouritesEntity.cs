
using System.ComponentModel.DataAnnotations;

namespace RentBuddyBackend.DAL.Entities
{
    public class FavouritesEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public virtual List<UserEntity>? Users { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace RentBuddyBackend.DAL.Entities
{
    public class BlacklistEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public virtual List<UserEntity?> Users { get; set; }
    }
}

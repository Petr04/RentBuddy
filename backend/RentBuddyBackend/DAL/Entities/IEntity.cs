using System.ComponentModel.DataAnnotations;

namespace RentBuddyBackend.DAL.Entities;

public interface IEntity
{
    [Key]
    public Guid Id { get; set; }
}
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Infrastructure;

public interface IMatchingService
{
    Dictionary<UserEntity, int> Match(UserEntity user, IEnumerable<UserEntity> users);
}
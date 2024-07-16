using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Modules.FavoriteRooms.Repository;
using RentBuddyBackend.Modules.RoomModule.Repository;

namespace RentBuddyBackend.Infrastructure;

public class MatchingService(IFavoriteRoomsRepository favoriteRoomsRepository, IRoomRepository roomRepository) : IMatchingService
{
    public Dictionary<UserEntity, int> Match(UserEntity user, IEnumerable<UserEntity> users)
    {
        var matchDictionary = new Dictionary<UserEntity, int>();

        var currentFavoriteRooms = favoriteRoomsRepository.FindAsync(user.FavoriteRoomsId).Result;


        foreach (var comparedUser in users)
        {
            
            var comparedFavoriteRooms = favoriteRoomsRepository
                .FindAsync(comparedUser.FavoriteRoomsId).Result.RoomsId
                .Select(id => roomRepository.FindAsync(id).Result);

            var isMatch = currentFavoriteRooms.RoomsId
                .Any(userRoom => comparedFavoriteRooms.Any(comparedUserRoom => comparedUserRoom.Id == userRoom));
            
            if (user.Id == comparedUser.Id || !isMatch)
                continue;

            var userRooms = currentFavoriteRooms;
            var comparedUserRooms = comparedFavoriteRooms;

            /*foreach (var userRoom  in userRooms)
            {
                userRoom.Se
            }*/

            var priorityPoints = 0;

            if (user.IsSmoke != comparedUser.IsSmoke)
                priorityPoints--;

            if (user.HasPet != comparedUser.HasPet)
                priorityPoints--;

            priorityPoints += Math.Abs(user.CommunicationLevel - comparedUser.CommunicationLevel)
                              + Math.Abs(user.PureLevel - comparedUser.PureLevel)
                              + Math.Abs(user.PureLevel - comparedUser.PureLevel)
                              - Math.Abs(CalculateTimeDifference(user.RiseTime, comparedUser.RiseTime))
                              - Math.Abs(CalculateTimeDifference(user.SleepTime, comparedUser.SleepTime));

            matchDictionary.Add(comparedUser, priorityPoints);
        }

        matchDictionary = matchDictionary.OrderByDescending(kvp => kvp.Value)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        
        return matchDictionary;
    }

    private static int CalculateTimeDifference(DateTime time1, DateTime time2)
    {
        var timeDifference = time1 - time2;

        return (int)Math.Floor(timeDifference.TotalMinutes);
    }
}
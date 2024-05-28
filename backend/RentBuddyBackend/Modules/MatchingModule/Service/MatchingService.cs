using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Infrastructure;

public class MatchingService : IMatchingService
{
    public Dictionary<UserEntity, int> Match(UserEntity user, IEnumerable<UserEntity> users)
    {
        var matchDictionary = new Dictionary<UserEntity, int>();

        foreach (var comparedUser in users)
        {
            var isMatch = user.FavoriteRooms?.Rooms?
                .Any(userRoom =>
                comparedUser.FavoriteRooms?.Rooms?
                    .Any(comparedUserRoom => comparedUserRoom.Id == userRoom.Id) 
                ?? false) 
                          ?? false;
            
            if (user.Id == comparedUser.Id || !isMatch)
                continue;

            var userRooms = user.FavoriteRooms?.Rooms;
            var comparedUserRooms = comparedUser.FavoriteRooms?.Rooms;

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
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Infrastructure;

public abstract class Matching : IMatching
{
    public static Dictionary<UserEntity, int> Match(UserEntity user, IEnumerable<UserEntity> users)
    {
        var matchDictionary = new Dictionary<UserEntity, int>();

        foreach (var comparedUser in users)
        {
            if (user.Id == comparedUser.Id)
                continue;
            
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
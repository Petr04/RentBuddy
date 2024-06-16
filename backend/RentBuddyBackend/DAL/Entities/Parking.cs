namespace RentBuddyBackend.DAL.Entities
{
    public class Parking
    {   
        /// <summary>
        /// Типы парковки
        /// </summary>
        public enum ParkingType 
        {   
            Underground,
            OpenInYard,
            GroundMultilevel,
            BehindBarrierInYard
        }
    }
}

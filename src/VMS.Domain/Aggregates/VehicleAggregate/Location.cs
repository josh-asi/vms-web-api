using VMS.Domain.SeedWork;

namespace VMS.Domain.Aggregates.VehicleAggregate
{
    public class Location : Entity
    {
        public Latitude Latitude { get; private set; }
        public Longitude Longitude { get; private set; }

        public Location(Latitude latitude, Longitude longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}

using VMS.Domain.SeedWork;

namespace VMS.Domain.Aggregates.VehicleAggregate
{
    public class Vehicle : Entity, IAggregateRoot
    {
        public VehicleType VehicleType { get; private set; }
        public Speed Speed { get; private set; }
        public Kilometres Mileage { get; private set; }
        public Location Location { get; private set; }

        public Vehicle(int id, VehicleType vehicleType, Speed speed, Kilometres mileage)
        {
            Id = id;
            VehicleType = vehicleType;
            Speed = speed;
            Mileage = mileage;
        }
    }
}

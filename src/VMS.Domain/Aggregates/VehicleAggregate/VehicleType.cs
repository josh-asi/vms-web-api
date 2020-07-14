namespace VMS.Domain.Aggregates.VehicleAggregate
{
    public enum VehicleType
    {
        Truck = 0,
        Bus = 1
    }

    public static class VehicleTypeExtensions
    {
        public static VehicleType ToVehicleType(this int type)
        {
            return (VehicleType)type;
        }
    }
}

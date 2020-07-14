namespace VMS.Domain.Aggregates.VehicleAggregate
{
    public enum VehicleType
    {
        Truck = 1,
        Bus = 2
    }

    public static class VehicleTypeExtensions
    {
        public static VehicleType ToVehicleType(this int type)
        {
            return (VehicleType)type;
        }

        public static string ToFriendlyString(this VehicleType code)
        {
            return System.Enum.GetName(code.GetType(), code);
        }
    }
}

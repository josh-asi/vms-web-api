namespace VMS.Domain.Aggregates.VehicleAggregate
{
    public enum VehicleType
    {
        Truck = 1,
        Bus = 2
    }

    public static class VehicleTypeExtensions
    {
        private const int minimumTypeValue = 1;
        private const int maximumTypeValue = 2;

        public static VehicleType ToVehicleType(this int type)
        {
            if (type < minimumTypeValue || type > maximumTypeValue)
                throw new DomainException($"The vehicle type must have a minimum value of {minimumTypeValue} and a maximum value of {maximumTypeValue}");

            return (VehicleType)type;
        }

        public static string ToFriendlyString(this VehicleType code)
        {
            return System.Enum.GetName(code.GetType(), code);
        }
    }
}

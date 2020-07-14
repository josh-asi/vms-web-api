namespace VMS.Domain.Aggregates.VehicleAggregate
{
    public class Speed
    {
        private double kilometresPerHour = 0.0;

        public Speed(double kilometresPerHour)
        {
            if (kilometresPerHour < 0.0) throw new DomainException("Speed must not be a negative number");
            this.kilometresPerHour = kilometresPerHour;
        }

        public static implicit operator double(Speed kilometresPerHour)
        {
            return kilometresPerHour.kilometresPerHour;
        }

        public static implicit operator Speed(double kilometresPerHour)
        {
            return new Speed(kilometresPerHour);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is double single ? single == kilometresPerHour : ((Speed)obj).kilometresPerHour == kilometresPerHour;
        }
    }
}

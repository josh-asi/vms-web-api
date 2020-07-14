namespace VMS.Domain.Aggregates.VehicleAggregate
{
    public class Speed
    {
        private float kilometresPerHour = 0.0f;

        public Speed(float kilometresPerHour)
        {
            if (kilometresPerHour < 0.0f) throw new DomainException("Speed must not be a negative number");
            this.kilometresPerHour = kilometresPerHour;
        }

        public static implicit operator float(Speed kilometresPerHour)
        {
            return kilometresPerHour.kilometresPerHour;
        }

        public static implicit operator Speed(float kilometresPerHour)
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

            return obj is float single ? single == kilometresPerHour : ((Speed)obj).kilometresPerHour == kilometresPerHour;
        }
    }
}

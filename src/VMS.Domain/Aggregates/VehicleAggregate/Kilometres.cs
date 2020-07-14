using VMS.Domain.SeedWork;

namespace VMS.Domain.Aggregates.VehicleAggregate
{
    public class Kilometres : ValueObject
    {
        private double kilometres = 0.0;

        public Kilometres(double kilometres)
        {
            if (kilometres < 0.0) throw new DomainException("Mileage must not be a negative number");

            this.kilometres = kilometres;
        }

        public void UpdateMileage(double kilometres)
        {
            if (kilometres < this.kilometres) throw new DomainException("The new mileage entered is smaller than the current mileage.");

            this.kilometres = kilometres;
        }

        public static implicit operator double(Kilometres kilometres)
        {
            return kilometres.kilometres;
        }

        public static implicit operator Kilometres(double kilometres)
        {
            return new Kilometres(kilometres);
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

            return obj is double single ? single == kilometres : ((Kilometres)obj).kilometres == kilometres;
        }
    }
}
